using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MurtleMod
{
    public class ModMain : MonoBehaviour
    {

        public static void Create()
        {
            new GameObject("ModHandler", new Type[]
            {
                typeof(ModMain)
            });
        }

        public void Start()
        {
            GameManager.Instance.ShowSubtitles("You are using Murtle's BATDR Mod", 2f, false);
        }

        public void Update()
        {
            if (this.player == null)
            {
                this.player = GameManager.Instance.Player.gameObject;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                GameManager.Instance.Player.gameObject.SetActive(true);
                GameManager.Instance.Player.enabled = true;
                GameManager.Instance.HideCutsceneBars();
                GameManager.Instance.Player.HeadContainer.SetParent(this.player.transform);
                GameManager.Instance.GameCamera.InitializeFreeRoamCam();
                GameManager.Instance.GameCamera.CameraContainer.SetParent(GameManager.Instance.GameCamera.HeadContainer);
                GameManager.Instance.GameCamera.CameraContainer.localPosition = Vector3.zero;
                GameManager.Instance.GameCamera.CameraContainer.localScale = Vector3.one;
                GameManager.Instance.Player.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                GameManager.Instance.GameCamera.HeadContainer.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                GameManager.Instance.GameCamera.CameraContainer.localEulerAngles = new Vector3(0f, 0f, 0f);
                GameManager.Instance.Player.UnlockRotation();
                GameManager.Instance.Player.SetCollision(true);
                GameManager.Instance.Player.SetAllTrackers(true);
                GameManager.Instance.Player.ShowFirstPersonArms();
                GameManager.Instance.Player.ExitAnimationCamera();
                GameManager.Instance.Player.ResetRotation();
                GameManager.Instance.Player.SetState(State.Player.Default);
                GameManager.Instance.Player.PlayerMovement.ResetMoveSpeed();
                GameManager.Instance.Player.PlayerMovement.UnlockCrouch();
                GameManager.Instance.Player.PlayerMovement.UnlockRun();
                GameManager.Instance.Player.PlayerMovement.UnlockJump();
                GameManager.Instance.ShowSubtitles("Character Unlocked", 2f, false);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                this.player.gameObject.transform.position += this.player.gameObject.transform.forward * 5f;
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                GameManager.Instance.Player.SetHealth(100);
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                GameManager.Instance.HideInspect();
                GameManager.Instance.HideHealthBar();
                GameManager.Instance.HideCrosshair();
                GameManager.Instance.HideInteraction();
                GameManager.Instance.HideSprintBar();
                GameManager.Instance.HideTeleport();
                GameManager.Instance.ShowSubtitles("UI Hidden", 1f, false);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                GameManager.Instance.ShowCrosshair();
                GameManager.Instance.ShowTeleport();
                GameManager.Instance.ShowSubtitles("UI Shown", 2f, false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                this.player.gameObject.transform.position += this.player.gameObject.transform.up * 10f;
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                this.player.gameObject.transform.position += this.player.gameObject.transform.up * -10f;
            }
        }
        public GameObject player;
    }
}

