using System;

namespace VisionControl
{
  partial class VisionControl
  {
    ///////////////////////// START WIZARD GENERATED
    // cognex.wizard.globals.begin
    private const string mVppFilename = @"C:\Users\lilywang\Desktop\视频录制\09 车牌识别\9.vpp";
    private const string mApplicationName = "车牌识别";
    private static bool mUsePasswords = false;
    private static bool mQuickBuildAccess = true;
    private const string mDefaultAdministratorPassword = "";
    private const string mDefaultSupervisorPassword = "";
    private static DateTime mGenerationDateTime = new DateTime(2021,11,22,10,49,30);
    private static string mGeneratedByVersion = "59.2.0.0";
    // cognex.wizard.globals.end
    ///////////////////////// END WIZARD GENERATED

    private void Wizard_FormLoad()
    {
      ///////////////////////// START WIZARD GENERATED
      // cognex.wizard.formloadactions
      ///////////////////////// END WIZARD GENERATED
    }

    private void Wizard_AttachPropertyProviders()
    {
      ///////////////////////// START WIZARD GENERATED
      // cognex.wizard.attachpropertyproviders
      ///////////////////////// END WIZARD GENERATED
    }

    private void Wizard_DetachPropertyProviders()
    {
      ///////////////////////// START WIZARD GENERATED
      // cognex.wizard.detachpropertyproviders
      ///////////////////////// END WIZARD GENERATED
    }

    private void Wizard_EnableControls(bool running)
    {
      ///////////////////////// START WIZARD GENERATED
      // cognex.wizard.enablecontrols
      ///////////////////////// END WIZARD GENERATED
    }

    private void Wizard_AddJobTabs(System.Collections.ArrayList newPagesList)
    {
      ///////////////////////// START WIZARD GENERATED
      // begin cognex.wizard.addjobtabs
      switch (mSelectedJob)
      {
        case 0:
          newPagesList.Add(tabPage_Job0_车牌识别);
          break;
      }
      // end cognex.wizard.addjobtabs
      ///////////////////////// END WIZARD GENERATED
    }

    private void Wizard_UpdateJobResults(int idx, Cognex.VisionPro.ICogRecord result)
    {
      ///////////////////////// START WIZARD GENERATED
      // begin cognex.wizard.updatejobresults
      switch (idx)
      {
        case 0:
          Utility.FillUserResultData(textBox_Job0_车牌, result, "cardplate", false);
          break;
      }
      // end cognex.wizard.updatejobresults
      ///////////////////////// END WIZARD GENERATED
    }

  }
}
