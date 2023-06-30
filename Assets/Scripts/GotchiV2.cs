using UnityEngine;

namespace com.mycompany
{
    public class GotchiV2 : MonoBehaviour
    {
        GotchiAppearance appearance;

        AavegotchiData.Facing facing = AavegotchiData.Facing.FRONT;
        AavegotchiData.HandPose handPose = AavegotchiData.HandPose.DOWN_CLOSED;

        private void Awake()
        {
            appearance = GetComponentInChildren<GotchiAppearance>();
        }

        public void Init(GotchiData data)
        {
            appearance.Init(data);
        }

        public void SetFacing(AavegotchiData.Facing facing)
        {
            this.facing = facing;
            appearance.SetFacing(facing);
        }

        public void SetHandPose(AavegotchiData.HandPose handPose)
        {
            this.handPose = handPose;
            appearance.SetHandPose(handPose);
        }
    }
}
