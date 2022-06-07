using System.Reflection;
using BepInEx;
using UnityEngine;
using HarmonyLib;

namespace EAExpandedCameraMod
{
    [BepInPlugin(ID, NAME, VERSION)]
    public class NathanLithiaBase : BaseUnityPlugin
    {
        const string ID = "EA-ExpandedCamera.io.github.nathanlithia";
        const string NAME = "Executive Assault Expanded Camera Mod.";
        const string VERSION = "1.0";
        void Awake()
        {
            Harmony harmony = new Harmony(ID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Debug.Log("Expanded Camera by NathanLithia!");

        }
    }
    [HarmonyPatch(typeof(RTS_camera2))]
    [HarmonyPatch("Start")]
    public class ExpandedCameraCode
    {
        [HarmonyPostfix]
        public static void Patch(ref float ___MaxHeight, ref Camera ___Camera)
        {
            Debug.Log("Injected new height into RTS_camera2");
            ___MaxHeight = (float)800;
            //___Camera.far = 1500;
            return;
        }
    }
}
