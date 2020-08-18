// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    public struct AppDescriptor
    {
        public LogCallback LogCallback;
        public LoopCallback LoopCallback;
        public QuitCallback QuitCallback;
        public KernelModuleTypes ModuleTypes;
    }
}
