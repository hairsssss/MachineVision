using System;

namespace VisionControl
{
  partial class VisionControl
  {
    ///////////////////////// START WIZARD GENERATED
    // cognex.wizard.globals.begin
    private const string mVppFilename = @"C:\Users\lilywang\Desktop\视频录制\15 药物胶囊瑕疵检测\15.vpp";
    private const string mApplicationName = "药物胶囊瑕疵检测";
    private static bool mUsePasswords = false;
    private static bool mQuickBuildAccess = true;
    private const string mDefaultAdministratorPassword = "";
    private const string mDefaultSupervisorPassword = "";
    private static DateTime mGenerationDateTime = new DateTime(2021,11,22,12,33,25);
    private static string mGeneratedByVersion = "59.2.0.0";
    // cognex.wizard.globals.end
    ///////////////////////// END WIZARD GENERATED

    private void Wizard_FormLoad()
    {
      ///////////////////////// START WIZARD GENERATED
      // begin cognex.wizard.formloadactions
      cogToolPropertyProvider0.ErrorProvider = applicationErrorProvider;
      Utility.SetupPropertyProvider(cogToolPropertyProvider0, textBox_Job0_检测结果, mJM.Job(0).VisionTool, "Tools.Item[\"CogToolBlock1\"].(Cognex.VisionPro.ToolBlock.CogToolBlock).Outputs.Item[\"result\"].Value.(System.String)");
      // end cognex.wizard.formloadactions
      ///////////////////////// END WIZARD GENERATED
    }

    private void Wizard_AttachPropertyProviders()
    {
      ///////////////////////// START WIZARD GENERATED
      // begin cognex.wizard.attachpropertyproviders
      cogToolPropertyProvider0.Subject = mJM.Job(0).VisionTool;
      // end cognex.wizard.attachpropertyproviders
      ///////////////////////// END WIZARD GENERATED
    }

    private void Wizard_DetachPropertyProviders()
    {
      ///////////////////////// START WIZARD GENERATED
      // begin cognex.wizard.detachpropertyproviders
      cogToolPropertyProvider0.Subject = null;
      // end cognex.wizard.detachpropertyproviders
      ///////////////////////// END WIZARD GENERATED
    }

    private void Wizard_EnableControls(bool running)
    {
      ///////////////////////// START WIZARD GENERATED
      // begin cognex.wizard.enablecontrols
      textBox_Job0_检测结果.Enabled = ! running;
      // end cognex.wizard.enablecontrols
      ///////////////////////// END WIZARD GENERATED
    }

    private void Wizard_AddJobTabs(System.Collections.ArrayList newPagesList)
    {
      ///////////////////////// START WIZARD GENERATED
      // begin cognex.wizard.addjobtabs
      switch (mSelectedJob)
      {
        case 0:
          newPagesList.Add(tabPage_Job0_检测);
          break;
      }
      // end cognex.wizard.addjobtabs
      ///////////////////////// END WIZARD GENERATED
    }

    private void Wizard_UpdateJobResults(int idx, Cognex.VisionPro.ICogRecord result)
    {
      ///////////////////////// START WIZARD GENERATED
      // begin cognex.wizard.updatejobresults
      // end cognex.wizard.updatejobresults
      ///////////////////////// END WIZARD GENERATED
    }

  }
}
