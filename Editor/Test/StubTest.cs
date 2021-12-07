using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System;

[TestFixture]
[Category("Namespace Tests")]
public class StubTest
{	
	[Test]
	public void CheckAssetsPath()
	{
		string examplePath = "C:/Windows/Test/Assets/example/path/is/here";
		string namespaceName = RobotlegsStubs.GetNamespace(examplePath, true);
		Assert.That(namespaceName, Is.EqualTo("example.path.is.here"));
	}

	[Test]
	public void CheckSrcPath()
	{
		string examplePath = "C:/Windows/Test/Assets/anotherfolder/src/example/path/is/here";
		string namespaceName = RobotlegsStubs.GetNamespace(examplePath, true);
		Assert.That(namespaceName, Is.EqualTo("example.path.is.here"));
	}

	[Test]
	public void CheckSrcPathUppercase()
	{
		string examplePath = "C:/Windows/Test/Assets/anotherfolder/SrC/example/path/is/here";
		string namespaceName = RobotlegsStubs.GetNamespace(examplePath, true);
		Assert.That(namespaceName, Is.EqualTo("example.path.is.here"));
	}

	[Test]
	public void CheckSourcePath()
	{
		string examplePath = "C:/Windows/Test/Assets/a/anotherfolder/source/example/path/is/here";
		string namespaceName = RobotlegsStubs.GetNamespace(examplePath, true);
		Assert.That(namespaceName, Is.EqualTo("example.path.is.here"));
	}

	[Test]
	public void CheckSourcePathUppercase()
	{
		string examplePath = "C:/Windows/Test/Assets/b/anotherfolder/SOURCE/example/path/is/here";
		string namespaceName = RobotlegsStubs.GetNamespace(examplePath, true);
		Assert.That(namespaceName, Is.EqualTo("example.path.is.here"));
	}

	[Test]
	public void CheckScriptsPath()
	{
		string examplePath = "C:/Windows/Test/Assets/a/anotherfolder/scripts/example/path/is/here";
		string namespaceName = RobotlegsStubs.GetNamespace(examplePath, true);
		Assert.That(namespaceName, Is.EqualTo("example.path.is.here"));
	}

	[Test]
	public void CheckScriptsPathUppercase()
	{
		string examplePath = "C:/Windows/Test/Assets/b/anotherfolder/SCrIpTs/example/path/is/here";
		string namespaceName = RobotlegsStubs.GetNamespace(examplePath, true);
		Assert.That(namespaceName, Is.EqualTo("example.path.is.here"));
	}

	[Test]
	public void CheckRootReturnsNoNamespace()
	{
		string examplePath = "C:/Windows/Test/Assets/b/anotherfolder/Scripts";
		string namespaceName = RobotlegsStubs.GetNamespace(examplePath, true);
		Assert.That(namespaceName, Is.EqualTo(""));
	}

	[Test]
	public void CheckRootReturnsNoNamespaceWithExtraSlash()
	{
		string examplePath = "C:/Windows/Test/Assets/b/anotherfolder/Scripts/";
		string namespaceName = RobotlegsStubs.GetNamespace(examplePath, true);
		Assert.That(namespaceName, Is.EqualTo(""));
	}
}
