using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Models
{
	public abstract class BaseModel
	{
		private static Dictionary<string, List<string>> classColumns = new Dictionary<string, List<string>>();
		public IEnumerable<string> GetColumnsName()
		{
			var type = GetType();
			var name = type.FullName;
			if (!classColumns.ContainsKey(name))
			{
				var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(prop => prop.CanWrite && prop.CanRead).Select(p => p.Name);
				classColumns[name] = new List<string>();
				classColumns[name].AddRange(props.ToList());
			}
			return classColumns[name];
		}

		public virtual string GetTableName() => GetType().Name;

		public string GetColumnsList(string prefix = "",string separator = ",")
		{
			return string.Join(separator, GetColumnsName().Select(m => prefix + m));
		}

		public string GetColumnsListWithoutID(string prefix = "", string separator = ",")
		{
			return string.Join(separator, GetColumnsName().Where(m => !m.Equals(GetIDColumnName(),System.StringComparison.OrdinalIgnoreCase)).Select(m => prefix + m));
		}

		public string GetIDColumnName()
		{
			return "ID";
		}
		public string GetUpdateColumnList() => string.Join(",", GetColumnsList().Select(m => $"{m} = @{m}"));

		public void SetID(int id) => GetType().GetProperty(GetIDColumnName()).SetValue(this, id);
	}
}
