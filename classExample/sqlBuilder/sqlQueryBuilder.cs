using System.Collections.Generic;

public class SqlQueryBuilder
{
    private string _table = "";
    private readonly List<string> _selectColumns = new List<string>();
    private readonly List<string> _whereConditions = new List<string>();
    private readonly List<string> _joins = new List<string>();
    private string _orderBy = "";

    public SqlQueryBuilder Select(params string[] columns)
    {
        if (columns == null || columns.Length == 0)
        {
            throw new ArgumentException("At least one column required");
        }
        _selectColumns.AddRange(columns);
        return this;
    }

    public SqlQueryBuilder From(string table)
    {
        if (string.IsNullOrWhiteSpace(table))
        {
            throw new ArgumentException("Table name cannot be null or empty");
        }

        _table = table;
        return this;
    }

    public SqlQueryBuilder Where(params string[] conditions)
    {
        if (conditions == null || conditions.Length == 0)
        {
            throw new ArgumentException("At least one condition required");
        }

        _whereConditions.AddRange(conditions);
        return this;
    }

    public SqlQueryBuilder Join(string joinClause)
    {
        _joins.Add(joinClause);
        return this;
    }

    public SqlQueryBuilder OrderBy(string orderBy)
    {
        _orderBy = orderBy;
        return this;
    }

    public string Build()
    {
        if (string.IsNullOrEmpty(_table))
        {
            throw new System.InvalidOperationException("FROM clause is required.");
        }

        string selectClause = _selectColumns.Count > 0 ? "SELECT " + string.Join(", ", _selectColumns) : "SELECT *";
        string fromClause = "FROM " + _table;
        string joinClause = _joins.Count > 0 ? string.Join(" ", _joins) : "";
        string whereClause = _whereConditions.Count > 0 ? "WHERE " + string.Join(" AND ", _whereConditions) : "";
        string orderByClause = !string.IsNullOrEmpty(_orderBy) ? "ORDER BY " + _orderBy : "";

        return $"{selectClause} {fromClause} {joinClause} {whereClause} {orderByClause}".Trim();
    }
}