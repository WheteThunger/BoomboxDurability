namespace Oxide.Plugins
{
    [Info("No Boom Box Condition Loss", "WhiteThunder", "1.0.0")]
    [Description("Prevents deployable boom boxes from losing condition while playing.")]
    internal class NoBoomBoxConditionLoss : CovalencePlugin
    {
        #region Fields

        private float? VanillaConditionLossRate = null;

        #endregion

        #region Hooks

        private void Init()
        {
            Unsubscribe(nameof(OnEntitySpawned));
        }

        private void OnServerInitialized()
        {
            foreach (var entity in BaseNetworkable.serverEntities)
            {
                var boomBox = entity as DeployableBoomBox;
                if (boomBox == null)
                    continue;
                
                OnEntitySpawned(boomBox);
            }

            Subscribe(nameof(OnEntitySpawned));
        }

        private void OnEntitySpawned(DeployableBoomBox boomBox)
        {
            if (VanillaConditionLossRate == null)
                VanillaConditionLossRate = boomBox.BoxController.ConditionLossRate;

            boomBox.BoxController.ConditionLossRate = 0;
        }

        private void Unload()
        {
            if (VanillaConditionLossRate == null)
                return;

            foreach (var entity in BaseNetworkable.serverEntities)
            {
                var boomBox = entity as DeployableBoomBox;
                if (boomBox == null)
                    continue;

                boomBox.BoxController.ConditionLossRate = (float)VanillaConditionLossRate;
            }
        }

        #endregion
    }
}
