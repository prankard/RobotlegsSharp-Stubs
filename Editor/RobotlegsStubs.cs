using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

public class RobotlegsStubs : EditorWindow
{
	private string appPath = "Scripts/Prankard/TestApp";
	private string appNamespace = "Prankard.TestApp";
	private string appName = "TestApp";

	private string extensionPath = "Scripts/Prankard/Extensions";
	private string extensionNamespace = "Prankard.Extensions";
	private string extensionName = "Test";

	private static string RootPath
	{
		get
		{
			return Path.Combine(Path.GetDirectoryName(Application.dataPath), Path.GetDirectoryName(GetMonoScriptPathFor(typeof(RobotlegsStubs))));
		}
	}

	public static string GetMonoScriptPathFor(Type type)
	{
		var asset = "";
		var guids = AssetDatabase.FindAssets(string.Format("{0} t:script", type.Name));
		if (guids.Length > 1)
		{
			foreach (var guid in guids)
			{
				var assetPath = AssetDatabase.GUIDToAssetPath(guid);
				var filename = Path.GetFileNameWithoutExtension(assetPath);
				if (filename == type.Name)
				{
					asset = guid;
					break;
				}
			}
		}
		else if (guids.Length == 1)
			asset = guids[0];
		else
		{
			Debug.LogErrorFormat("Unable to locate {0}", type.Name);
			return null;
		}
		return AssetDatabase.GUIDToAssetPath(asset);
	}

	[MenuItem ("Window/Robotlegs Stubs")]
	static void Init()
	{
		// Get existing open window or if none, make a new one:
		RobotlegsStubs window = (RobotlegsStubs)EditorWindow.GetWindow (typeof (RobotlegsStubs));
		window.Show();
	}

	void OnGUI()
	{
		EditorGUILayout.LabelField("Create App", EditorStyles.boldLabel);

		appPath = EditorGUILayout.TextField("App Path", appPath);
		appNamespace = EditorGUILayout.TextField("App Namespace", appNamespace);
		appName = EditorGUILayout.TextField("App Name", appName);
		if (GUILayout.Button("Create App Stub"))
		{
			ReplaceString[] replaceStrings = new ReplaceString[]{
				new ReplaceString("AppNamespace", appNamespace),
				new ReplaceString("AppName", appName),
			};
			CreateStub(RootPath + "/AppStub", "Assets/" + appPath, replaceStrings);
			Debug.Log("Created app at: " + appPath);
		}

		GUILayout.Space(20);
		EditorGUILayout.LabelField("Create Extension", EditorStyles.boldLabel);

		extensionPath = EditorGUILayout.TextField("Extension Path", extensionPath);
		extensionNamespace = EditorGUILayout.TextField("Extension Namespace", extensionNamespace);
		extensionName = EditorGUILayout.TextField("Extension Name", extensionName);
		if (GUILayout.Button("Create Extension Stub"))
		{
			ReplaceString[] replaceStrings = new ReplaceString[]{
				new ReplaceString("ExtensionNamespace", extensionNamespace),
				new ReplaceString("ExtensionName", extensionName),
			};
			CreateStub(RootPath + "/ExtensionStub", "Assets/" + extensionPath, replaceStrings);
			Debug.Log("Created extension at: " + extensionPath);
		}

		GUILayout.Space(20);
		EditorGUILayout.LabelField("Debug", EditorStyles.boldLabel);

		if (GUILayout.Button("Rename all .stub to stub.cs"))
		{
			string[] paths = AssetDatabase.GetAllAssetPaths();
			foreach (string file in paths)
			{
				if (Path.GetExtension(file) == ".stub" && Path.GetExtension(Path.GetFileNameWithoutExtension(file)) == ".cs")
				{
					string newFile = file + ".cs";
					//UnityEngine.Debug.Log(file + " -> " + newFile);
					AssetDatabase.MoveAsset(file, newFile);
				}
			}
			AssetDatabase.Refresh();
		}
		if (GUILayout.Button("Rename all .stub.cs to .stub"))
		{
			string[] paths = AssetDatabase.GetAllAssetPaths();
			string searchStubCS = ".stub.cs";
			foreach (string file in paths)
			{
				if (file.LastIndexOf(searchStubCS) == file.Length - searchStubCS.Length)
				{
					string newFile = file.Substring(0, file.Length - searchStubCS.Length) + ".stub";
					//UnityEngine.Debug.Log(file + " -> " + newFile);
					AssetDatabase.MoveAsset(file, newFile);
				}
			}
			AssetDatabase.Refresh();
		}
	}

	[MenuItem("Assets/Create/Scriptable Object", true)]
	static bool CreateScriptableObjectValidation()
	{
		if (!(Selection.activeObject is MonoScript))
			return false;
		if (!typeof(ScriptableObject).IsAssignableFrom((Selection.activeObject as MonoScript).GetClass()))
			return false;
		return true;
	}

	[MenuItem("Assets/Create/Scriptable Object")]
	static void CreateScriptableObject()
	{
		string path = AssetDatabase.GetAssetPath (Selection.activeObject);
		string filename = Path.GetFileNameWithoutExtension(path) + ".asset";
			
		if (path == "") 
		{
			return;
		}

		if (Path.GetExtension (path) != "") 
		{
			path = path.Replace (Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
		}

		UnityEngine.Debug.Log(path);
		UnityEngine.Debug.Log(Path.Combine(path, filename));

		string assetPath = AssetDatabase.GenerateUniqueAssetPath(Path.Combine(path, filename));
		UnityEngine.Debug.Log(assetPath);

		if (Selection.activeObject is MonoScript)
		{
			Type classType = (Selection.activeObject as MonoScript).GetClass();
			if (!typeof(ScriptableObject).IsAssignableFrom(classType))
			{
				UnityEngine.Debug.Log("Cannot make VO from non-scriptable object");
				return;
			}
			ScriptableObject instance = ScriptableObject.CreateInstance(classType);
			AssetDatabase.CreateAsset(instance as UnityEngine.Object, assetPath);
			AssetDatabase.SaveAssets ();
			AssetDatabase.Refresh();
			EditorUtility.FocusProjectWindow ();
			Selection.activeObject = instance;
		}
	}

	//[MenuItem("Assets/CreateStubFromFolder")]
	public static void Test()
    {
		Debug.Log("This is a test");
		if (Selection.activeObject == null)
			return;

		if (Selection.activeObject is DefaultAsset)
        {
			var folder = Selection.activeObject as DefaultAsset;
			var rootPath = AssetDatabase.GetAssetPath(folder);
			Debug.Log(rootPath);
			if (Directory.Exists(rootPath))
            {
				Debug.Log("It's a folder");
				var dirs = Directory.GetDirectories(rootPath);
				var rootFolderName = Path.GetDirectoryName(rootPath);
				foreach (var dir in dirs)
                {
					Debug.Log(dir);
					var currentFolderName = Path.GetDirectoryName(dir);
					// Content = =
					/*
					 

	[MenuItem("Assets/Create/Robotlegs/MonoBehaviour")]
	static void CreateRobotlegsMonobehaviour1()
	{
		CreateRobotlegsMonobehaviour();
	}

	[MenuItem("Assets/Robotlegs/MonoBehaviour")]
	static void CreateRobotlegsMonobehaviour()
	{
		RobotlegsStubs.CreateRightClickFile("MonoBehaviour", "ExampleMonoBehaviour", "Enter MonoBehaviour ClassName", RootPath + "/RightClickMenu/MonoBehaviour");
	}
					 */


					var prefix = "Assets/";
					var s = "[MenuItem(\"" + prefix + rootFolderName + "/" + currentFolderName + "\")]";
					Debug.Log(s);
                }
            }
        }
    }

	public static void CreateRightClickFile(string dialogTitle, string defaultFilename, string dialogDescription, string sourceFilePath, string dialogExtension = "cs")
	{
		UnityEngine.Object activeObject = Selection.activeObject;
		//UnityEngine.Debug.Log(activeObject);

		string selectionPath;// = AssetDatabase.GetAssetPath(activeObject);
		if (activeObject == null)
			return;
		
			selectionPath = AssetDatabase.GetAssetPath(activeObject);
		//else
		//	selectionPath = "Assets/";

		//Debug.Log(selectionPath);

		//string selectionPath = AssetDatabase.GetAssetPath(activeObject);
		string selectionFullPath = Path.Combine(Application.dataPath, Path.Combine("../", selectionPath));
		string selectionPathDirectory = Directory.Exists(selectionFullPath) ? selectionPath : Path.GetDirectoryName(selectionPath);

		string destinationPath = EditorUtility.SaveFilePanelInProject(dialogTitle, defaultFilename, dialogExtension, dialogDescription, selectionPathDirectory);

		if (string.IsNullOrEmpty(destinationPath))
			return;

		string filename = Path.GetFileNameWithoutExtension(destinationPath);

		if (destinationPath.Length > 5 && destinationPath.Substring(0, 6) == "Assets")
		{
			string destinationFullPath = Path.Combine(Path.Combine(Application.dataPath, "../"), destinationPath);
			if (File.Exists(destinationFullPath))
			{
				UnityEngine.Debug.LogWarning("File already exists at destination path: " + destinationPath);
				return;
			}

			string destinationDirectory = Path.GetDirectoryName(destinationFullPath);

			ReplaceString[] replaceStrings = new ReplaceString[]{
				new ReplaceString("FileName", filename)
			};
			CreateStub(sourceFilePath,  destinationDirectory, replaceStrings);
		}
	}

	private static void CreateStub(string searchPath, string targetPath, IEnumerable<ReplaceString> replaceStrings)
	{
		Directory.CreateDirectory(targetPath);
		string[] files = Directory.GetFiles(searchPath);
		foreach (string filePath in files)
		{
			if (Path.GetExtension(filePath).ToLower() != ".stub")
				continue;
			
			string filename = Path.GetFileName(filePath);
			filename = filename.Substring(0, filename.Length - 5); // remove .stub
			string newFilename = Replace(filename, replaceStrings);
			string content = File.ReadAllText(filePath);
			List<ReplaceString> replaceStringsWithNamespace = new List<ReplaceString>(replaceStrings);
			replaceStringsWithNamespace.Add(new ReplaceString("NamespaceName", GetNamespace(targetPath)));
			content = Replace(content, replaceStringsWithNamespace);
			File.WriteAllText(Path.Combine(targetPath, newFilename), content);
		}
		foreach (string directoryPath in Directory.GetDirectories(searchPath))
		{
			string directoryName = Path.GetFileName(directoryPath);
			string newDirectoryName = Replace(directoryName, replaceStrings);
			string targetDirectoryFullPath = Path.Combine(targetPath, newDirectoryName);
			CreateStub(directoryPath, targetDirectoryFullPath, replaceStrings);
		}
		AssetDatabase.Refresh();
	}

	public static string GetNamespace(string filePath, bool toLower = false)
	{
		filePath = filePath.Replace('\\', '/');
		string[] rootPaths = new string[]{"Assets", "Scripts", "src", "source"};
		foreach (string rootPath in rootPaths)
		{
			int index = filePath.LastIndexOf(rootPath + "/", System.StringComparison.CurrentCultureIgnoreCase);
			if (index > -1)
				filePath = filePath.Substring(index + rootPath.Length + 1);

			// Check the last folder
			index = filePath.LastIndexOf ("/" + rootPath, System.StringComparison.CurrentCultureIgnoreCase);
			if (index == filePath.Length - rootPath.Length - 1)
				return "";
		}
		string namespaceName = filePath;
		namespaceName = namespaceName.Replace('/', '.');
		if (toLower)
		{
			namespaceName = namespaceName.ToLower();
		}
		return namespaceName;
	}

	private static string Replace(string target, IEnumerable<ReplaceString> replaceStrings)
	{
		foreach (ReplaceString rs in replaceStrings)
		{
			target = target.Replace(rs.find, rs.replace);
			//*
			string findLower = rs.find.ToLower();
			string replaceLower = rs.replace.ToLower();
			if (findLower != rs.find)
				target = target.Replace(findLower, replaceLower);
			//*/
		}
		return target;
	}

	public struct ReplaceString
	{
		public string find;
		public string replace;

		public ReplaceString(string find, string replace)
		{
			this.find = find;
			this.replace = replace;
		}
	}
}
