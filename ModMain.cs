using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
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

        public GameObject player;
        public Vector3 positionSaved1;
        public bool infiniteSprint;
        public bool infiniteHealth;

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
                this.infiniteHealth = !this.infiniteHealth;
                bool flag3 = this.infiniteHealth;
                if (flag3)
                {
                    GameManager.Instance.Player.SetHealth(999999);
                    GameManager.Instance.ShowSubtitles("Infinite Health On", 2f, false);
                }
                else
                {
                    GameManager.Instance.Player.SetHealth(100);
                    GameManager.Instance.ShowSubtitles("Infinite Health Off", 2f, false);
                }
                this.infiniteHealth = !this.infiniteHealth;
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
            if (Input.GetKeyDown(KeyCode.M))
            {
                GameManager.Instance.GameData.CurrentSave.PlayerData.Statistics.AddBattery();
                GameManager.Instance.ShowSubtitles("Added +1 Battery for Current Save", 2f, false);
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                GameManager.Instance.GameData.AutoSave(true, null);
                GameManager.Instance.ShowSubtitles("Saved game as Auto Save", 2f, false);
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                GameManager.Instance.GameData.CurrentSave.PlayerData.Statistics.AddPart();
                GameManager.Instance.ShowSubtitles("Added +1 Gent Part for Current Save", 2f, false);
            }
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                GameManager.Instance.GameData.CurrentSave.PlayerData.Statistics.AddSlugs(10);
                GameManager.Instance.ShowSubtitles("Added +10 Slugs for Current Save", 2f, false);
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                GameManager.Instance.GameData.CurrentSave.PlayerData.Statistics.AddToolkit();
                GameManager.Instance.ShowSubtitles("Added +1 Toolkit for Current Save", 2f, false);
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                GameManager.Instance.GameData.CurrentSave.PlayerData.Statistics.AddBatteryCasing();
                GameManager.Instance.ShowSubtitles("Added +1 Battery Casing for Current Save", 2f, false);
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                GameManager.Instance.GameData.CurrentSave.PlayerData.Statistics.AddCard();
                GameManager.Instance.ShowSubtitles("Added +1 Gent Card for Current Save", 2f, false);
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                bool flag = this.infiniteSprint;
                if (flag)
                {
                    typeof(Player).GetField("m_RunCooldown", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(GameManager.Instance.Player, 0f);
                    GameManager.Instance.ShowSubtitles("Infinite Sprint On", 2f, false);
                }
                else
                {
                    typeof(Player).GetField("m_RunCooldown", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(GameManager.Instance.Player, 5f);
                    GameManager.Instance.ShowSubtitles("Infinite Sprint Off", 2f, false);
                }
                this.infiniteSprint = !this.infiniteSprint;
               
            }
            if (Input.GetKeyDown(KeyCode.LeftBracket))
            {
                this.positionSaved1 = this.player.transform.position;
                GameManager.Instance.ShowSubtitles("Saved Positon 1", 2f, false);
            }
            if (Input.GetKeyDown(KeyCode.RightBracket))
            {
                this.player.transform.position = this.positionSaved1;
                GameManager.Instance.ShowSubtitles("Teleported to Point 1", 2f, false);
            }
            if (Input.GetKeyDown(KeyCode.))
            if (Input.GetKeyDown(KeyCode.U))
            {
                GameManager.Instance.Player.SetCollision(!GameManager.Instance.Player.CharacterController.enabled);
                bool flag2 = !GameManager.Instance.Player.CharacterController.enabled;
                if (flag2)
                {
                    GameManager.Instance.ShowSubtitles("Player frozen", 2f, false);
                }   
                else
                {
                    GameManager.Instance.ShowSubtitles("Player unfrozen", 2f, false);
                }
            }
        }
    }
}

