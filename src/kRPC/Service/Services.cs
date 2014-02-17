﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Google.ProtocolBuffers;
using KRPC.Schema.KRPC;
using KRPC.Utils;

namespace KRPC.Service
{
    class Services
    {
        //TODO: determine the assembly from the namespace
        public static Response.Builder HandleRequest (Request request)
        {
            Logger.WriteLine("Handling client request");
            // Get the service method
            var serviceType = GetServiceType (request.Service);
            MethodInfo handler = GetServiceMethod(serviceType, request.Method);

            // Get the optional parameter
            object parameter = null;
            if (handler.GetParameters().Length == 1) {
                Type type = handler.GetParameters () [0].ParameterType;
                Logger.WriteLine("Decoding parameter");
                // TODO: check the type is an IMessage
                MethodInfo createBuilder = type.GetMethod ("CreateBuilder", new Type[] {});
                IBuilder parameterBuilder = (IBuilder) createBuilder.Invoke (null, null);
                parameter = parameterBuilder.WeakMergeFrom (request.Request_).WeakBuild ();
                Logger.WriteLine("Successfully decoded parameter");
            }
            // TODO: check if there are more parameter - this isn't allowed

            // Invoke the handler
            object[] parameters = { };
            if (parameter != null)
                parameters = new object[] { parameter };
            Logger.WriteLine("Invoking handler");
            object result = handler.Invoke (null, parameters);
            Logger.WriteLine("Handler returned successfully");

            // Build the response
            var responseBuilder = Response.CreateBuilder();

            // Process the optional result
            if (result != null) {
                Logger.WriteLine("Processing result");
                byte[] resultBytes;
                using (MemoryStream stream = new MemoryStream ()) {
                    ((IMessage)result).WriteTo (stream);
                    resultBytes = stream.ToArray ();
                }
                Logger.WriteLine("Result processed successfully");
                responseBuilder.Response_ = ByteString.CopyFrom (resultBytes);
            }

            return responseBuilder;
        }

        private static List<Type> services;

        /// <summary>
        /// Get a the C# type of a service by name.
        /// </summary>
        private static Type GetServiceType(string name) {
            if (services == null)
                services = Reflection.GetTypesWith<KRPCService> ().ToList ();
            try {
                return services.Where (x => x.Name == name).ToList ().First ();
            } catch (InvalidOperationException) {
                throw new NoSuchServiceException (name);
            }
        }

        /// <summary>
        /// Get a the C# method information of a service method by name.
        /// </summary>
        private static MethodInfo GetServiceMethod(Type service, string name) {
            MethodInfo method = service.GetMethod (name, BindingFlags.Public | BindingFlags.Static);
            if (method == null)
                throw new NoSuchServiceMethodException (service, name);
            if (method.GetCustomAttributes(typeof(Service.KRPCMethod), false).Length == 0)
                throw new NoSuchServiceMethodException (service, name);
            return method;
        }
    }
}

