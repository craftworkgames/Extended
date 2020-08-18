// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    public struct LogMessageDescriptor
    {
        public string CompileTimeFilePath;
        public int CompileTimeLineNumber;
        public string CompileTimeMemberName;
        public string Summary;
        public string Details;
    }
}
