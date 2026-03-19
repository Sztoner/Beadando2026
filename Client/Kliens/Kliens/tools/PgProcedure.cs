using Npgsql;
using NpgsqlTypes;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System;

public class PgProcedure : IAsyncDisposable
{
    public PgProcedure(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public PgProcedure(string connectionString, string procedureName)
    {
        ConnectionString = connectionString;
        ProcedureName = procedureName;
    }

    string ConnectionString;
    List<Parameter> Parameters = new List<Parameter>();
    public string ProcedureName { get; set; } = "";
    public int ResultSets { get; set; } = 0;

    private NpgsqlConnection connection;
    private NpgsqlTransaction transaction;
    private NpgsqlCommand command;
    private NpgsqlDataReader reader;
    private bool disposed = false;

    public async ValueTask DisposeAsync()
    {
        disposed = true;
        if (reader != null)
        {
            await reader.DisposeAsync();
        }
        if (command != null)
        {
            await command.DisposeAsync();
        }
        if (transaction != null)
        {
            await transaction.CommitAsync();
            await transaction.DisposeAsync();
        }
        if (connection != null)
        {
            await connection.DisposeAsync();
        }
    }

    public string CreateProcedureCall()
    {
        List<string> resultSets = Enumerable.Range(1, ResultSets).Select(i => $"r{i}").ToList();
        List<string> parameterList = Parameters.Select(p => $"@{p.Name}").ToList();
        parameterList.AddRange(resultSets.Select(r => $"'{r}'"));
        string parameters = string.Join(", ", parameterList);
        string fetches = string.Join("", resultSets.Select(r => $"\nFETCH ALL FROM {r};"));

        return $"CALL {ProcedureName}({parameters});{fetches}";
    }

    void LoadParameters()
    {
        foreach (var p in Parameters)
        {
            if (p.Size != null && p.Type != null)
            {
                command.Parameters.AddWithValue(p.Name, p.Type.Value, p.Size.Value, p.Value);
            }
            else if (p.Type != null)
            {
                command.Parameters.AddWithValue(p.Name, p.Type.Value, p.Value);
            }
            else
            {
                command.Parameters.AddWithValue(p.Name, p.Value);
            }
        }
    }

    async Task Connect()
    {
        connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();
        transaction = await connection.BeginTransactionAsync();
        string sql = CreateProcedureCall();
        command = new NpgsqlCommand(sql, connection, transaction);
        LoadParameters();
    }

    public async Task<NpgsqlDataReader> ExecuteReaderAsync()
    {
        if (ResultSets == 0)
        {
            ResultSets = 1;
        }
        await Connect();
        reader = await command.ExecuteReaderAsync();
        await reader.NextResultAsync();
        return reader;
    }

    public async Task<int> ExecuteNonReaderAsync()
    {
        ResultSets = 0;
        await Connect();
        return await command.ExecuteNonQueryAsync();
    }

    public async Task<bool> NextResultAsync()
    {
        return await reader.NextResultAsync();
    }

    public bool NextResult()
    {
        return reader.NextResult();
    }

    public void AddParameter(string name, NpgsqlDbType type, int size, object value)
    {
        Parameters.Add(new Parameter(name, value, type, size));
    }

    public void AddParameter(string name, NpgsqlDbType type, object value)
    {
        Parameters.Add(new Parameter(name, value, type));
    }

    public void AddParameter(string name, object value)
    {
        Parameters.Add(new Parameter(name, value));
    }

    ~PgProcedure()
    {
        if (!disposed)
        {
            _ = DisposeAsync();
        }
    }

    class Parameter
    {
        public string Name;
        public object Value;
        public NpgsqlDbType? Type;
        public int? Size;

        public Parameter(string name, object value, NpgsqlDbType type, int size)
        {
            Name = name;
            Value = value;
            Type = type;
            Size = size;
        }

        public Parameter(string name, object value, NpgsqlDbType type)
        {
            Name = name;
            Value = value;
            Type = type;
            Size = null;
        }

        public Parameter(string name, object value)
        {
            Name = name;
            Value = value;
            Type = null;
            Size = null;
        }
    }
}