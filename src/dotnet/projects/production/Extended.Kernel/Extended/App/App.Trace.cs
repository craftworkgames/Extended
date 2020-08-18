// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Diagnostics;
using System.Text;

namespace Extended
{
    public static partial class App
    {
        private static readonly StringBuilder _traceSummary = new StringBuilder();
        private static readonly StringBuilder _traceParameters = new StringBuilder();
        private static readonly StringBuilder _traceMessage = new StringBuilder();

        [Conditional("TRACE")]
        internal static void BeginTrace(string summary)
        {
            CreateBeginTraceMessage(summary, out var message);
            LogInfo(message);
        }

        [Conditional("TRACE")]
        internal static void BeginTrace<T>(string summary, (string name, T value) param)
        {
            var message = CreateBeginTraceMessage(summary, param);
            LogInfo(message);
        }

        [Conditional("TRACE")]
        internal static void BeginTrace<T1, T2>(string summary, (string name, T1 value) param1, (string name, T2 value) param2)
        {
            var message = CreateBeginTraceMessage(summary, param1, param2);
            LogInfo(message);
        }

        [Conditional("TRACE")]
        internal static void EndTraceSuccess()
        {
            var message = CreateTraceSuccessMessage();
            LogInfo(message);
        }

        [Conditional("TRACE")]
        internal static void EndTraceSuccess<T>((string name, T value) param)
        {
            var message = CreateTraceSuccessMessage(param);
            LogInfo(message);
        }

        [Conditional("TRACE")]
        internal static void EndTraceFailure()
        {
            var message = CreateTraceFailureMessage();
            LogCritical(message);
        }

        [Conditional("TRACE")]
        internal static void EndTraceFailure(Exception exception)
        {
            var message = CreateTraceFailureMessage(exception);
            LogCritical(message);
        }

        [Conditional("TRACE")]
        internal static void EndTraceFailure<T>((string name, T value) param)
        {
            var message = CreateTraceFailureMessage(param);
            LogCritical(message);
        }

        private static void CreateBeginTraceMessage(string summary, out string message)
        {
            _traceSummary.Clear();
            _traceSummary.Append(summary);

            _traceParameters.Clear();

            _traceMessage.Clear();
            _traceMessage.Append(_traceSummary);
            _traceMessage.Append("...");

            message = _traceMessage.ToString();
        }

        private static string CreateBeginTraceMessage<T>(string summary, (string name, T value) param)
        {
            _traceSummary.Clear();
            _traceSummary.Append(summary);

            _traceParameters.Clear();
            var (paramName, paramValue) = param;

            _traceParameters.Append(paramName);
            _traceParameters.Append(": ");
            _traceParameters.Append(paramValue);

            _traceMessage.Clear();
            _traceMessage.Append(_traceSummary);
            _traceMessage.Append("...");
            _traceMessage.Append(Environment.NewLine);
            _traceMessage.Append("\t{ ");
            _traceMessage.Append(_traceParameters);
            _traceMessage.Append(" }");

            return _traceMessage.ToString();
        }

        private static string CreateBeginTraceMessage<T1, T2>(string summary, (string name, T1 value) param1, (string name, T2 value) param2)
        {
            _traceSummary.Clear();
            _traceSummary.Append(summary);

            _traceParameters.Clear();
            var (paramName1, paramValue1) = param1;

            _traceParameters.Append(paramName1);
            _traceParameters.Append(": ");
            _traceParameters.Append(paramValue1);
            _traceParameters.Append(", ");

            var (paramName2, paramValue2) = param2;
            _traceParameters.Append(paramName2);
            _traceParameters.Append(": ");
            _traceParameters.Append(paramValue2);

            _traceMessage.Clear();
            _traceMessage.Append(_traceSummary);
            _traceMessage.Append("...");
            _traceMessage.Append(Environment.NewLine);
            _traceMessage.Append("\t{ ");
            _traceMessage.Append(_traceParameters);
            _traceMessage.Append(" }");

            return _traceMessage.ToString();
        }

        private static string CreateTraceSuccessMessage()
        {
            _traceMessage.Clear();
            _traceMessage.Append(_traceSummary);
            _traceMessage.Append(": Success.");

            if (_traceParameters.Length > 0)
            {
                _traceMessage.Append(Environment.NewLine);
                _traceMessage.Append("\t{ ");
                _traceMessage.Append(_traceParameters);
                _traceMessage.Append("}");
            }

            var message = _traceMessage.ToString();
            return message;
        }

        private static string CreateTraceSuccessMessage<T>((string name, T value) param)
        {
            _traceMessage.Clear();
            _traceMessage.Append(_traceSummary);
            _traceMessage.Append(": Success.");

            if (_traceParameters.Length > 0)
            {
                _traceMessage.Append(Environment.NewLine);
                _traceMessage.Append("\t{ ");
                _traceMessage.Append(_traceParameters);
                _traceMessage.Append(" }");
            }

            _traceMessage.Append(Environment.NewLine);
            _traceMessage.Append("\t{ ");
            var (name, value) = param;
            _traceMessage.Append(name);
            _traceMessage.Append(": ");
            _traceMessage.Append(value);
            _traceMessage.Append(" }");

            var message = _traceMessage.ToString();
            return message;
        }

        private static string CreateTraceFailureMessage()
        {
            _traceMessage.Clear();
            _traceMessage.Append(_traceSummary);
            _traceMessage.Append(": Failure.");

            if (_traceParameters.Length > 0)
            {
                _traceMessage.Append(Environment.NewLine);
                _traceMessage.Append("\t{ ");
                _traceMessage.Append(_traceParameters);
                _traceMessage.Append(" }");
            }

            return _traceMessage.ToString();
        }

        private static string CreateTraceFailureMessage<T>((string name, T value) param)
        {
            _traceMessage.Clear();
            _traceMessage.Append(_traceSummary);
            _traceMessage.Append(": Failure.");

            if (_traceParameters.Length > 0)
            {
                _traceMessage.Append(Environment.NewLine);
                _traceMessage.Append("\t{ ");
                _traceMessage.Append(_traceParameters);
                _traceMessage.Append(" }");
            }

            _traceMessage.Append(Environment.NewLine);
            _traceMessage.Append("\t{ ");
            var (name, value) = param;
            _traceMessage.Append(name);
            _traceMessage.Append(": ");
            _traceMessage.Append(value);
            _traceMessage.Append(" }");

            return _traceMessage.ToString();
        }

        private static string CreateTraceFailureMessage(Exception exception)
        {
            _traceMessage.Clear();
            _traceMessage.Append(_traceSummary);
            _traceMessage.Append(": Failure.");

            if (_traceParameters.Length > 0)
            {
                _traceMessage.Append(Environment.NewLine);
                _traceMessage.Append("\tInput: { ");
                _traceMessage.Append(_traceParameters);
                _traceMessage.Append("} ");
            }

            _traceMessage.Append(Environment.NewLine);
            _traceMessage.Append("\tException: ");
            _traceMessage.Append(exception.Message);
            _traceMessage.Append(Environment.NewLine);
            _traceMessage.Append(exception.StackTrace);

            return _traceMessage.ToString();
        }
    }
}
