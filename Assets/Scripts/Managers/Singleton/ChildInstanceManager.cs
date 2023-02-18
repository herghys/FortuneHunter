using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class ChildInstanceManager : GenericSingleton<ChildInstanceManager>
    {
        [SerializeField] GameInstance gameInstance;

        public GameInstance GameInstanceRef { get => gameInstance; set { gameInstance = value;} }
    }
}
