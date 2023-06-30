using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace com.mycompany
{
    public class GotchiUI : MonoBehaviour
    {
        [SerializeField]
        GotchiV2 gotchi;

        [SerializeField]
        int currentGotchi;

        int facing = 0;
        int handsPosition = 0;

        public void SetCurrentGotchi(int currentGotchi)
        {
            this.currentGotchi = currentGotchi;
        }

        private void Start()
        {
            loadGotchi();
            // InvokeRepeating("moveHands", 0.5f, 1f);
            // InvokeRepeating("turn", 0.5f, 1f);
        }

        public void turn(int direction)
        {
            facing = direction;
            switch(facing)
            {
                case 0: gotchi.SetFacing(AavegotchiData.Facing.FRONT); break;
                case 1: gotchi.SetFacing(AavegotchiData.Facing.LEFT); break;
                case 2: gotchi.SetFacing(AavegotchiData.Facing.BACK); break;
                case 3: gotchi.SetFacing(AavegotchiData.Facing.RIGHT); break;
            }   
        }

        void turn()
        {
            facing = (facing + 1) % 4;
            switch(facing)
            {
                case 0: gotchi.SetFacing(AavegotchiData.Facing.FRONT); break;
                case 1: gotchi.SetFacing(AavegotchiData.Facing.LEFT); break;
                case 2: gotchi.SetFacing(AavegotchiData.Facing.BACK); break;
                case 3: gotchi.SetFacing(AavegotchiData.Facing.RIGHT); break;
            }   
        }

        // // add some code to raise and lower hands of the gotchi based on it's current facing
        void moveHands()
        {
            handsPosition = (handsPosition + 1) % 2;
            switch(handsPosition)
            {
                case 0: gotchi.SetHandPose(AavegotchiData.HandPose.DOWN_OPEN); break;
                case 1: gotchi.SetHandPose(AavegotchiData.HandPose.UP); break;
            }   
        }

        CancellationTokenSource cts;

        async void loadGotchi()
        {
            if (cts != null)
            {
                cts.Cancel();
            }

            cts = new CancellationTokenSource();

            try
            {
                var gotchiData = await GraphManager.Instance.GetGotchi(currentGotchi.ToString(), cts.Token);
                if (gotchiData != null && gotchiData.collateral != null)
                {
                    gotchi.gameObject.SetActive(true);
                    gotchi.Init(gotchiData);
                }
                else
                {
                    Debug.Log("Invalid Gotchi Id");
                    gotchi.gameObject.SetActive(false);
                }
            }
            catch (OperationCanceledException ex)
            {
                Debug.LogError(ex.Message);
            }
        }

    }
}
