using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class RightClickMenu : Editor
{
	private static string _rootPath;

	private static string RootPath
	{
		get
		{
			if (_rootPath == null)
			{
				Type t = MethodBase.GetCurrentMethod().DeclaringType;
				_rootPath = Path.Combine(Path.GetDirectoryName(Application.dataPath), Path.GetDirectoryName(RobotlegsStubs.GetMonoScriptPathFor(t)));
			}
			return _rootPath;
		}
	}

	[MenuItem("Assets/Create/Robotlegs/MonoBehaviour")]
	static void CreateRobotlegsMonobehaviour1()
	{
		CreateRobotlegsMonobehaviour();
	}

	[MenuItem("Assets/Create/Robotlegs/Config")]
	static void CreateRobotlegsConfig1()
	{
		CreateRobotlegsConfig();
	}

	[MenuItem("Assets/Create/Robotlegs/Command")]
	static void CreateRobotlegsCommand1()
	{
		CreateRobotlegsCommand();
	}

	[MenuItem("Assets/Create/Robotlegs/Guard")]
	static void CreateRobotlegsGuard1()
	{
		CreateRobotlegsGuard();
	}

	[MenuItem("Assets/Create/Robotlegs/Hook")]
	static void CreateRobotlegsHook1()
	{
		CreateRobotlegsHook();
	}

	[MenuItem("Assets/Create/Robotlegs/Event")]
	static void CreateRobotlegsEvent1()
	{
		CreateRobotlegsEvent();
	}

	[MenuItem("Assets/Create/Robotlegs/Model")]
	static void CreateRobotlegsModel1()
	{
		CreateRobotlegsModel();
	}

	[MenuItem("Assets/Create/Robotlegs/Service")]
	static void CreateRobotlegsService1()
	{
		CreateRobotlegsService();
	}

	[MenuItem("Assets/Create/Robotlegs/Parser")]
	static void CreateRobotlegsParser1()
	{
		CreateRobotlegsParser();
	}

	[MenuItem("Assets/Create/Robotlegs/View")]
	static void CreateRobotlegsView1()
	{
		CreateRobotlegsView();
	}

	[MenuItem("Assets/Create/Robotlegs/IView")]
	static void CreateRobotlegsIView1()
	{
		CreateRobotlegsIView();
	}

	[MenuItem("Assets/Create/Robotlegs/Mediator")]
	static void CreateRobotlegsMediator1()
	{
		CreateRobotlegsMediator();
	}

	[MenuItem("Assets/Create/Robotlegs/ViewMediator")]
	static void CreateRobotlegsViewMediator1()
	{
		CreateRobotlegsViewMediator();
	}

	[MenuItem("Assets/Robotlegs/MonoBehaviour")]
	static void CreateRobotlegsMonobehaviour()
	{
		RobotlegsStubs.CreateRightClickFile("MonoBehaviour", "ExampleMonoBehaviour", "Enter MonoBehaviour ClassName", RootPath + "/RightClickMenu/MonoBehaviour");
	}

	[MenuItem("Assets/Robotlegs/Config")]
	static void CreateRobotlegsConfig()
	{
		RobotlegsStubs.CreateRightClickFile("Config", "ExampleConfig", "Enter Config ClassName", RootPath + "/RightClickMenu/Config");
	}

	[MenuItem("Assets/Robotlegs/Command")]
	static void CreateRobotlegsCommand()
	{
		RobotlegsStubs.CreateRightClickFile("Command", "ExampleCommand", "Enter Command ClassName", RootPath + "/RightClickMenu/Command");
	}

	[MenuItem("Assets/Robotlegs/Guard")]
	static void CreateRobotlegsGuard()
	{
		RobotlegsStubs.CreateRightClickFile("Guard", "ExampleGuard", "Enter Guard ClassName", RootPath + "/RightClickMenu/Guard");
	}

	[MenuItem("Assets/Robotlegs/Hook")]
	static void CreateRobotlegsHook()
	{
		RobotlegsStubs.CreateRightClickFile("Hook", "ExampleHook", "Enter Hook ClassName", RootPath + "/RightClickMenu/Hook");
	}

	[MenuItem("Assets/Robotlegs/Event")]
	static void CreateRobotlegsEvent()
	{
		RobotlegsStubs.CreateRightClickFile("Event", "ExampleEvent", "Enter Event ClassName", RootPath + "/RightClickMenu/Event");
	}

	[MenuItem("Assets/Robotlegs/Model")]
	static void CreateRobotlegsModel()
	{
		RobotlegsStubs.CreateRightClickFile("Model", "ExampleModel", "Enter Model ClassName", RootPath + "/RightClickMenu/Model");
	}

	[MenuItem("Assets/Robotlegs/Service")]
	static void CreateRobotlegsService()
	{
		RobotlegsStubs.CreateRightClickFile("Service", "ExampleService", "Enter Service ClassName", RootPath + "/RightClickMenu/Service");
	}

	[MenuItem("Assets/Robotlegs/Parser")]
	static void CreateRobotlegsParser()
	{
		RobotlegsStubs.CreateRightClickFile("Parser", "ExampleParser", "Enter Parser ClassName", RootPath + "/RightClickMenu/Parser");
	}

	[MenuItem("Assets/Robotlegs/View")]
	static void CreateRobotlegsView()
	{
		RobotlegsStubs.CreateRightClickFile("View", "ExampleView", "Enter View ClassName", RootPath + "/RightClickMenu/View");
	}

	[MenuItem("Assets/Robotlegs/IView")]
	static void CreateRobotlegsIView()
	{
		RobotlegsStubs.CreateRightClickFile("IView", "IExampleView", "Enter IView Interface Name", RootPath + "/RightClickMenu/IView");
	}

	[MenuItem("Assets/Robotlegs/Mediator")]
	static void CreateRobotlegsMediator()
	{
		RobotlegsStubs.CreateRightClickFile("Mediator", "ExampleMediator", "Enter Mediator ClassName", RootPath + "/RightClickMenu/Mediator");
	}

	[MenuItem("Assets/Robotlegs/ViewMediator")]
	static void CreateRobotlegsViewMediator()
	{
		RobotlegsStubs.CreateRightClickFile("ViewMediator", "ExampleView", "Enter View ClassName", RootPath + "/RightClickMenu/ViewMediator");
	}
}
