// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    public struct AppDescriptorCallbacks
    {
        public LogCallback? Log;
        public AppQuitCallback? Quit;
        public AppUpdateCallback? Update;
        public AppFixedUpdateCallback? UpdateFixed;
        public AppDrawCallback? Draw;
    }
}
