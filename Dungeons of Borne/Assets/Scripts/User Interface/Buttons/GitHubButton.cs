
using UnityEngine;

namespace UserInterface.Buttons
{
    class GitHubButton : Button
    {
        public string link = string.Empty;

        public override void Action()
        {
            base.Action();
            Application.OpenURL( link );
        }
    }
}