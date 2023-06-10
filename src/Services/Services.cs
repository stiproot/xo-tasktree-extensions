namespace Xo.TaskTree.Extensions.Services;

static class Utils
{
	public static int ProcessTimeGenerator(int min = 50, int max = 500) => new System.Random().Next(min, max);
}

public interface IService { Task<long> GetLongAsync(string query); }
public interface IGenericService<T>
{
    Task<T> GetGenericTypeAsync(string query);
}

public interface IY_InStr_OutBool_AsyncService { Task<bool> GetBoolAsync(string args); }
public class Y_InStr_OutBool_AsyncService : IY_InStr_OutBool_AsyncService
{
	public async Task<bool> GetBoolAsync(string args)
	{
		await Task.Delay(Utils.ProcessTimeGenerator());
		return true;
	}
}

public interface IY_InStr_OutInt_AsyncService { Task<int> GetIntAsync(string args); }
public class Y_InStr_OutInt_AsyncService : IY_InStr_OutInt_AsyncService
{
	public async Task<int> GetIntAsync(string args)
	{
		var processTime = Utils.ProcessTimeGenerator();
		await Task.Delay(processTime);
		return processTime;
	}
}

public interface IY_InStr_OutConstInt_AsyncService { Task<int> GetConstIntAsync(string args); }
public class Y_InStr_OutConstInt_AsyncService : IY_InStr_OutConstInt_AsyncService
{
	public async Task<int> GetConstIntAsync(string args)
	{
		var processTime = Utils.ProcessTimeGenerator();
		await Task.Delay(processTime);
		return 1;
	}
}

public interface IY_InBoolStr_OutConstInt_AsyncService { Task<int> GetConstIntAsync(bool flag, string args); }
public class Y_InBoolStr_OutConstInt_AsyncService : IY_InBoolStr_OutConstInt_AsyncService
{
	public async Task<int> GetConstIntAsync(bool flag, string args)
	{
		var processTime = Utils.ProcessTimeGenerator();
		await Task.Delay(processTime);
		return 1;
	}
}

public interface IY_InObjBool_OutStr_AsyncService { Task<string> GetStrAsync(object args2, bool flag2); }
public class Y_InObjBool_OutStr_AsyncService : IY_InObjBool_OutStr_AsyncService
{
	public async Task<string> GetStrAsync(object args2, bool flag2)
	{
		await Task.Delay(Utils.ProcessTimeGenerator());
		return string.Empty;
	}
}

public interface IY_InObjBool_OutNullStr_AsyncService { Task<string?> GetStrAsync(object args2, bool flag2); }
public class Y_InObjBool_OutNullStr_AsyncService : IY_InObjBool_OutNullStr_AsyncService
{
	public async Task<string?> GetStrAsync(object args2, bool flag2)
	{
		await Task.Delay(Utils.ProcessTimeGenerator());
		return null;
	}
}

public interface IY_InObjBool_OutBool_AsyncService { Task<bool> GetBoolAsync(object args2, bool flag2); }
public class Y_InObjBool_OutBool_AsyncService : IY_InObjBool_OutBool_AsyncService
{
	public async Task<bool> GetBoolAsync(object args2, bool flag2)
	{
		await Task.Delay(Utils.ProcessTimeGenerator());
		return true;
	}
}

public interface IY_InBool_OutBool_AsyncService { Task<bool> GetBoolAsync(bool flag); }
public class Y_InBool_OutBool_AsyncService : IY_InBool_OutBool_AsyncService
{
	public async Task<bool> GetBoolAsync(bool flag)
	{
		await Task.Delay(Utils.ProcessTimeGenerator());
		return true;
	}
}

public interface IY_InStr_AsyncService { Task ProcessStrAsync(string args3); }
public class Y_InStr_AsyncService : IY_InStr_AsyncService
{
	public async Task ProcessStrAsync(string args3)
	{
		await Task.Delay(Utils.ProcessTimeGenerator());
	}
}

public interface IY_InStrBool_AsyncService { Task ProcessStrBool(string args3, bool flag3); }
public class Y_InStrBool_AsyncService : IY_InStrBool_AsyncService
{
	public async Task ProcessStrBool(string args3, bool flag3)
	{
		await Task.Delay(Utils.ProcessTimeGenerator());
	}
}

public interface IY_InStrBool_OutStr_AsyncService { Task<string> GetStrAsync(string args3, bool flag3); }
public class Y_InStrBool_OutStr_AsyncService : IY_InStrBool_OutStr_AsyncService
{
	public async Task<string> GetStrAsync(string args3, bool flag3)
	{
		await Task.Delay(Utils.ProcessTimeGenerator());
		return "some string";
	}
}

public interface IY_AsyncService { Task ProcessAsync(); }
public class Y_AsyncService : IY_AsyncService
{
	public async Task ProcessAsync()
	{
		await Task.Delay(Utils.ProcessTimeGenerator());
	}
}

public interface IY_InObj_OutObj_SingletonAsyncService { Task<object> GetObjAsync(object arg1); }
public class Y_InObj_OutObj_SingletonAsyncService : IY_InObj_OutObj_SingletonAsyncService
{
	public async Task<object> GetObjAsync(object arg1)
	{
		// Simulate some process time
		await Task.Delay(Utils.ProcessTimeGenerator());
		return new object();
	}
}

public interface IY_InObjObj_OutObj_AsyncService { Task<object> GetObjAsync(object arg1, object arg2); }
public class Y_InObjObj_OutObj_AsyncService : IY_InObjObj_OutObj_AsyncService
{
	public async Task<object> GetObjAsync(object arg1, object arg2)
	{
		await Task.Delay(Utils.ProcessTimeGenerator());
		return new object();
	}
}

public interface IY_SyncService { void Process(); }
public class Y_SyncService : IY_SyncService
{
	public void Process() { }
}

public interface IY_OutConstBool_SyncService { bool GetBool(); }
public class Y_OutConstBool_SyncService : IY_OutConstBool_SyncService
{
	public bool GetBool() => true;
}

public interface IY_InInt_OutBool_SyncService { bool GetBool(int sleep); }
public class Y_InInt_OutBool_SyncService : IY_InInt_OutBool_SyncService
{
	public bool GetBool(int sleep)
	{
		Thread.Sleep(sleep);
		return true;
	}
}

public interface IY_InStrStrStr_OutConstInt_AsyncService
{
	Task<int> GetConstIntAsync(
		string arg1,
		string arg2,
		string arg3
	);
}
public class Y_InStrStrStr_OutConstInt_AsyncService : IY_InStrStrStr_OutConstInt_AsyncService
{
	public async Task<int> GetConstIntAsync(
		string arg1,
		string arg2,
		string arg3
	)
	{
		await Task.Delay(Utils.ProcessTimeGenerator());
		return 1;
	}
}
