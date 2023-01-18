#if UNITY_EDITOR
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class WebglPreBuildProcessing : IPreprocessBuildWithReport
{
  public int callbackOrder => 1;

  public void OnPreprocessBuild(BuildReport report)
  {
    System.Environment.SetEnvironmentVariable(
      "EMSDK_PYTHON",
      //"/Library/Frameworks/Python.framework/Versions/3.10/bin/python3.10"
      "/usr/local/bin/python3"
    );
  }
}
#endif
