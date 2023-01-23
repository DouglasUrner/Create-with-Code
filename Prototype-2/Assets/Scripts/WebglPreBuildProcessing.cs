#if UNITY_EDITOR

/*
** Set up the WebGL build environment for Unity < 2021.3.41f1 on
** macOS versions later than 12.3 (Monteray) where Apple has removed
** the system version of Python. Add this script and install Python 3,
** adjust the path to match where you have Python 3 installed.
*/

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
