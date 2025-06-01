using EmberLib.Glow;
using Lawo.EmberPlusSharp;
using Lawo.EmberPlusSharp.Glow;
using Lawo.EmberPlusSharp.Model;
using Lawo.EmberPlusSharp.S101;
using Lawo.Reflection;
using Lawo.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static EmberLib.Glow.GlowTags;
using static System.Net.Mime.MediaTypeNames;



namespace EmberMinimal
{


    class Program
    {

        

        private static async Task<S101Client> ConnectAsync(string host, int port)
        {
            // Create TCP connection
            var tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(host, port);

            // Establish S101 protocol
            // S101 provides message packaging, CRC integrity checks and a keep-alive mechanism.
            var stream = tcpClient.GetStream();
            return new S101Client(tcpClient, stream.ReadAsync, stream.WriteAsync);
        }

        // Note that the most-derived subtype MyRoot needs to be passed to the generic base class.
        private sealed class MyRoot : DynamicRoot<MyRoot>
        {
        }



        //public static void WriteChildren(INode node, int depth)
        //{
        //    Dictionary<string, string> nodeProperties = new Dictionary<string, string>();
        //    var indent = new string(' ', 2 * depth);

        //    for (int i = 0; i < node.Children.Count; i++)
        //    {
        //        var childNode = node.Children[i] as INode;


        //        if (childNode != null)
        //        {
        //            //Console.WriteLine("                                               Node Groene bladeren  {0}Node {1}", indent, child.Identifier);

        //            Console.WriteLine(childNode.Parent.Identifier);

        //            Console.WriteLine(indent, childNode.Parent.IsRoot);

        //            //nodeProperties[$"{childNode.Identifier}"] = " Node Groene bladjes";  // Make key unique
        //            WriteChildren(childNode, depth + 1);
        //        }

        //        //else
        //        //{
        //        //    var childParameter = node.Children[i] as IParameter;

        //        //    if (childParameter != null)
        //        //    {

        //        //        Console.WriteLine( indent, childParameter.Identifier, childParameter.Value);
        //        //        Console.WriteLine("Blauwe bolletjes  ", indent, childParameter.Identifier, childParameter.Value);

        //        //    }
        //        //}
        //    }

        //  //GenerateClass("EmberPlusNode", nodeProperties);

        //}




        //private static void WriteChildren(INode node, int depth)
        //{
        //    var indent = new string(' ', 2 * depth);
        //    foreach (var child in node.Children)
        //    {
        //        if (child is INode childNode)
        //        {
        //            Console.WriteLine($"{indent}Node {childNode.Identifier}");
        //            WriteChildren(childNode, depth + 1);
        //        }
        //        else if (child is IParameter childParameter)
        //        {
        //            Console.WriteLine($"{indent}Parameter {childParameter.Identifier}: {childParameter.Value}");
        //        }
        //    }
        //}

        public static int teller = 0;

        private static void WriteChildren(INode node)
        {
            for (int i = 0; i < node.Children.Count; i++)
            {
                var child = node.Children[i];
                teller++;





                


                if (child is INode childNode)
                {
                    //if (teller > 449 && teller < 461)
                 //   if (teller == 473 || teller == 476 || teller == 383 || teller == 382 || teller == 1)                    
                    {
                        Console.WriteLine("                      " + teller + "  " + childNode.Identifier + "  " + childNode.GetPath());
                    }

                    WriteChildren(childNode);    // Recursive opnieuw aanroepen van de zelfde functie                                                 // net zo lang tot er geen kinderen meer zijn               
                }
                ////else if (child is IParameter childParameter)
                ////{
                ////    //if (teller == 474 || teller == 476 || teller == 383 || teller == 382 || teller == 1)
                ////    //if (teller > 449 && teller < 481)
                ////   // if (teller == 476)
                ////    {
                ////        Console.WriteLine("                                              " + teller + "  " + childParameter.Identifier + "  " + childParameter.Number);
                ////        Console.WriteLine("                                                                                      " + teller + "  " + childParameter.Value?.GetType().Name);
                ////    }
                ////}




                //if (child is IParameter parameter)
                //{
                //    Console.WriteLine($" Type: {parameter.Value?.GetType().Name}");
                //}



            }
        }





        //public static int teller = 0;
        //private static StringBuilder sb = new StringBuilder();

        //public static void WriteChildren(INode node)
        //{
        //    for (int i = 0; i < node.Children.Count; i++)
        //    {
        //        var child = node.Children[i];
        //        teller++;

        //        if (child is INode childNode)
        //        {
        //            sb.AppendLine($"public {childNode.GetType().Name} {childNode.Identifier} {{ get; set; }}");
        //            WriteChildren(childNode);
        //        }
        //        else if (child is IParameter childParameter)
        //        {
        //            sb.AppendLine($"public {childParameter.GetType().Name} {childParameter.Identifier} {{ get; set; }}");
        //        }
        //    }
        //}

        //public static void GenerateClassFile(string className)
        //{
        //    string classTemplate = $@"public class {className}{{{sb.ToString()}}}";

        //    System.IO.File.WriteAllText($"{className}.cs", classTemplate);
        //}




        private static StringBuilder classBuilder = new StringBuilder(100000);

        //StringBuilder classBuilder = new StringBuilder(100000);



        public static void GenerateClass(string className, Dictionary<string, string> properties)
        {

            //classBuilder.AppendLine("using System;");
            //classBuilder.AppendLine($"public class {className}");
            //classBuilder.AppendLine("{");

            //for (int i = 0; i < properties.Count(); i++)
            //{
            //    var property = properties.ElementAt(i);
            //    classBuilder.AppendLine($"   Key: {property.Key}, Value: {property.Value} {{ get; set; }}");
            //}

            //classBuilder.AppendLine("}");


            //File.WriteAllText($"{className}.cs", classBuilder.ToString());       // Write the class to a file


            //for (int i = 0; i < properties.Count; i++)
            //{
            //    var property = properties.ElementAt(i);
            //    Console.WriteLine($"Key: {property.Key}, Value: {property.Value}");
            //}

        }


        private static void Main()
        {
            // This is necessary so that we can execute async code in a console application.
            AsyncPump.Run(
            async () =>
            {               
                using (S101Client client = await ConnectAsync("localhost", 9000))
                using (Consumer<MyRoot> consumer = await Consumer<MyRoot>.CreateAsync(client))
                {
                    // INode node = consumer.Root;



                    WriteChildren(consumer.Root);

                   // GenerateClassFile("test.cs");

                    ////var indent = new string(' ', 2 * 0);

                    //////for (int i = 0; i < 1; i++)
                    //////{
                    ////var child = node.Children[0];

                    ////    if (child is INode childNode)
                    ////    {
                    ////        WriteChildren(childNode, 0 + 1);
                    ////    }
                    //////}
                }
            });
            Console.WriteLine("\nDone. Press Enter to exit.");
            Console.ReadLine();
        }
    }

}

//// Establish S101 protocol
//using (S101Client client = await ConnectAsync("localhost", 9000))
//// Retrieve *all* elements in the provider database and store them in a local copy
//using (Consumer<MyRoot> consumer = await Consumer<MyRoot>.CreateAsync(client))
//    {

//        // Retrieve node properties dynamically
//        Dictionary<string, string> nodeProperties = new Dictionary<string, string>();

//        foreach (var node in consumer.GetNodes())
//        {
//            nodeProperties[node.Identifier] = node.Value.ToString();
//        }


//        //  WriteChildren(consumer.Root, 0);

//        // Get the root of the local database.
//        // INode root = consumer.Root;

//        // For now just output the number of direct children under the root node.
//        // Thread.Sleep(2000);
//        ///////Console.WriteLine(root.Children.Count.ToString());
//        // Thread.Sleep(200);

//        // INode root = consumer.Root;

//        //// // Navigate to the parameters we're interested in.
//        //// var auron = (INode)root.Children.First(c => c.Identifier == "auron");
//        ////// var identity = (INode)auron.Children.First(c => c.Identifier == "identity");
//        //// var modules = (INode)auron.Children.First(c => c.Identifier == "modules");
//        //// var module_1 = (INode)modules.Children.First(c => c.Identifier == "module_1");
//        //// var level = (IParameter)module_1.Children.First(c => c.Identifier == "level");

//        //// // Set parameters to the desired values.
//        //// level.Value = 1023L;

//        //// await consumer.SendAsync();



//        //// // Navigate to the parameter we're interested in.
//        //// var sapphire = (INode)root.Children.First(c => c.Identifier == "auron");
//        //// // var sources = (INode)sapphire.Children.First(c => c.Identifier == "Sources");
//        //// var fpgm1 = (INode)sapphire.Children.First(c => c.Identifier == "modules");
//        //// var fader = (INode)fpgm1.Children.First(c => c.Identifier == "module_1");
//        //// var positionParameter = fader.Children.First(c => c.Identifier == "level");

//        //// var valueChanged = new TaskCompletionSource<string>();
//        //// positionParameter.PropertyChanged += (s, e) => valueChanged.SetResult(((IElement)s).GetPath());
//        //// Console.WriteLine("Waiting for the parameter to change...");
//        //// Console.WriteLine("A value of the element with the path {0} has been changed.", await valueChanged.Task);
//        //// // Console.WriteLine(IntegerParameter.ng());
//}