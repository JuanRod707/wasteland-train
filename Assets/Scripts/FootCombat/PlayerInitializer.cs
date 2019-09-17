using Assets.Scripts.Common;
using Assets.Scripts.FootCombat.Entities;
using UnityEngine;

namespace Assets.Scripts.FootCombat
{
    public class PlayerInitializer : MonoBehaviour
    {
        public FollowAnchor CameraAnchor;
        public Character PlayerCharacter;

        void Start()
        {
            CameraAnchor.AnchorTo(PlayerCharacter.transform);
        }
  
    }
}
