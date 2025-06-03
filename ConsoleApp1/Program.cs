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

        //////////public static int teller = 0;

        //////////private static void WriteChildren(INode node)
        //////////{
        //////////    for (int i = 0; i < node.Children.Count; i++)
        //////////    {
        //////////        var child = node.Children[i];
        //////////        teller++;

        //////////        if (child is INode childNode)
        //////////        {
        //////////            //if (teller > 449 && teller < 461)
        //////////         //   if (teller == 473 || teller == 476 || teller == 383 || teller == 382 || teller == 1)                    
        //////////            {
        //////////               // Console.WriteLine("                      " + teller + "  " + childNode.Identifier + "  " + childNode.GetPath());
        //////////                Console.WriteLine("                      " + childNode.GetPath());
        //////////            }

        //////////            WriteChildren(childNode);    // Recursive opnieuw aanroepen van de zelfde functie                                                 // net zo lang tot er geen kinderen meer zijn               
        //////////        }
        //////////        else if (child is IParameter childParameter)
        //////////        {
        //////////            //if (teller == 474 || teller == 476 || teller == 383 || teller == 382 || teller == 1)
        //////////            //if (teller > 449 && teller < 481)
        //////////            // if (teller == 476)
        //////////            {
        //////////                //Console.WriteLine("                                              " + teller + "  " + childParameter.Identifier + "  " + childParameter.Number);
        //////////                //Console.WriteLine("                                                                                      " + teller + "  " + childParameter.Value?.GetType().Name);

        //////////                Console.WriteLine("                                              " + childParameter.Identifier);
        //////////                Console.WriteLine("                                                                                      " +childParameter.Value?.GetType().Name);
        //////////            }
        //////////        }
        //////////    }
        //////////}
        /// <summary>
        /// 





        //private static Dictionary<string, List<string>> classDefinitions = new Dictionary<string, List<string>>();

        //public static void WriteChildren(INode node)
        //{
        //    for (int i = 0; i < node.Children.Count; i++)
        //    {
        //        var child = node.Children[i];

        //        if (child is INode childNode)
        //        {
        //            string className = childNode.Identifier;

        //            if (!classDefinitions.ContainsKey(className))
        //            {
        //                classDefinitions[className] = new List<string>();
        //            }

        //            WriteChildren(childNode);
        //        }
        //        else if (child is IParameter childParameter)
        //        {
        //            string parentClass = node.Identifier;
        //            string propertyName = childParameter.Identifier;
        //            string propertyType = childParameter.Value?.GetType().Name ?? "object";

        //            if (!classDefinitions.ContainsKey(parentClass))
        //            {
        //                classDefinitions[parentClass] = new List<string>();
        //            }

        //            classDefinitions[parentClass].Add($"   [Element(Identifier = \"{propertyName}\")]");
        //            classDefinitions[parentClass].Add($"   internal {propertyType} {propertyName} {{ get; private set; }}");
        //        }
        //    }
        //}

        //public static void DisplayClasses()
        //{
        //    Console.WriteLine("public partial class GetSet");
        //    Console.WriteLine("{");

        //    foreach (var classDef in classDefinitions)
        //    {
        //        Console.WriteLine($"   //---------------------------------------------------------------------");
        //        Console.WriteLine($"   // {classDef.Key} class");
        //        Console.WriteLine($"   //---------------------------------------------------------------------");
        //        Console.WriteLine($"   public sealed class {classDef.Key} : FieldNode<{classDef.Key}>");
        //        Console.WriteLine("   {");

        //        foreach (var property in classDef.Value)
        //        {
        //            Console.WriteLine($"       {property}");
        //        }

        //        Console.WriteLine("   }");
        //        Console.WriteLine();
        //    }

        //    Console.WriteLine("}");
        //}







        //public static int stop, teller = 0;

        //private static Dictionary<string, string> parentChildMapping = new Dictionary<string, string>();
        //private static Dictionary<string, List<string>> classDefinitions = new Dictionary<string, List<string>>();

        //public static void WriteChildren(INode node)
        //{
        //    stop++;
        //    //if (stop > 18) return;

        //    string parentClass = node.Identifier;

        //    if (!classDefinitions.ContainsKey(parentClass))
        //    {
        //        classDefinitions[parentClass] = new List<string>();
        //    }

        //    for (int i = 0; i < node.Children.Count; i++)
        //    {
        //        var child = node.Children[i];

        //        if (child is INode childNode)
        //        {
        //            string childClass = childNode.Identifier;
        //            parentChildMapping[parentClass] = childClass; // Ensuring hierarchy


        //            if (childClass != string.Empty)
        //            {
        //                classDefinitions[parentClass].Add($"   internal {childClass.Remove(childClass.Length - 2)}{teller} {childClass.ToLower()} {{ get; private set; }}");

        //            }

        //            WriteChildren(childNode);

        //        }
        //        //else if (child is IParameter childParameter)
        //        //{
        //        //    string propertyName = childParameter.Identifier;
        //        //    string propertyType = childParameter.Value?.GetType().Name ?? "object";

        //        //    classDefinitions[parentClass].Add($"   [Element(Identifier = \"{propertyName}\")]");
        //        //    classDefinitions[parentClass].Add($"   internal {propertyType} {propertyName} {{ get; private set; }}");

        //        //}

        //    }

        //}

        //public static void DisplayClasses()
        //{
        //    //Console.WriteLine("public partial class GetSet");

        //    Console.WriteLine($"   public sealed class AuronRoot : Root<AuronRoot>");
        //    //Console.WriteLine("   {");

        //    //Console.WriteLine($"         internal auron auron {{get; private set; }}");
        //    //Console.WriteLine("   }");


        //    // Console.WriteLine("{");

        //    foreach (var classDef in classDefinitions)
        //    {

        //        //Console.WriteLine($"   //---------------------------------------------------------------------");
        //        //Console.WriteLine($"   // {classDef.Key} class");
        //        //Console.WriteLine($"   //---------------------------------------------------------------------");
        //        if (classDef.Key != string.Empty)
        //        {
        //            Console.WriteLine($"   public sealed class {classDef.Key.Remove(classDef.Key.Length - 2)}{teller} : FieldNode<{classDef.Key.Remove(classDef.Key.Length - 2)}{teller}>");

        //        }
        //        Console.WriteLine("   {");

        //        foreach (var property in classDef.Value)
        //        {
        //            Console.WriteLine($"       {property}");

        //        }



        //        Console.WriteLine("   }");
        //        Console.WriteLine();
        //    }

        //    //Console.WriteLine("}");

        //}







        //private static Dictionary<string, List<string>> classDefinitions = new Dictionary<string, List<string>>();
        //// public static void WriteChildren(INode node, int depth)
        //public static void WriteChildren(INode node)
        //{
        //    for (int i = 0; i < node.Children.Count; i++)
        //    {
        //        var child = node.Children[i];

        //        if (child is INode childNode)
        //        {
        //            string className = childNode.Identifier;

        //            if (!classDefinitions.ContainsKey(className))
        //            {
        //                classDefinitions[className] = new List<string>();
        //            }

        //            WriteChildren(childNode);
        //        }
        //        else if (child is IParameter childParameter)
        //        {
        //            string parentClass = node.Identifier;
        //            string propertyName = childParameter.Identifier;
        //            string propertyType = childParameter.Value?.GetType().Name ?? "object";

        //            if (!classDefinitions.ContainsKey(parentClass))
        //            {
        //                classDefinitions[parentClass] = new List<string>();
        //            }

        //            classDefinitions[parentClass].Add($"public {propertyType} {propertyName} {{ get; private set; }}");
        //        }
        //    }
        //}

        //public static void GenerateClassFile(string fileName)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    foreach (var classDef in classDefinitions)
        //    {
        //        sb.AppendLine($"public class {classDef.Key}");
        //        sb.AppendLine("{");

        //        foreach (var property in classDef.Value)
        //        {
        //            sb.AppendLine($"    {property}");
        //        }

        //        sb.AppendLine("}");
        //        sb.AppendLine();
        //    }

        //    File.WriteAllText(fileName, sb.ToString());
        //    Console.WriteLine($"Class file '{fileName}' generated successfully!");
        //}








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










        public static int stop, teller = 0;
        private static HashSet<string> uniqueClasses = new HashSet<string>(); // Ensure class names are unique
        private static Dictionary<string, HashSet<string>> classDefinitions = new Dictionary<string, HashSet<string>>();
        private static HashSet<string> existingDefinitions = new HashSet<string>(); // Prevent repeated class entries

        public static void WriteChildren(INode node)
        {
            string parentClass = node.Identifier;

            stop++;
            //if (stop > 8) return;

            if (!classDefinitions.ContainsKey(parentClass))
            {
                classDefinitions[parentClass] = new HashSet<string>(); // HashSet prevents duplicate properties
            }

            for (int i = 0; i < node.Children.Count; i++)
                {
                var child = node.Children[i];

                if (child is INode childNode)
                {
                    string childClass = childNode.Identifier;

                   // if (!uniqueClasses.Contains(childClass) && !existingDefinitions.Contains(childClass)) // Prevent duplicates
                    {
                        uniqueClasses.Add(childClass);
                        existingDefinitions.Add(childClass); // Track defined classes

                        //classDefinitions[parentClass].Add($"   internal {childClass} {childClass.ToLower()} {{ get; private set; }}");
                        classDefinitions[parentClass].Add($"   internal {childClass} {childClass} {{ get; private set; }}");
                    }

                    WriteChildren(childNode);
                }
                else if (child is IParameter childParameter)
                {
                    string propertyName = childParameter.Identifier;
                    string propertyType = childParameter.Value?.GetType().Name ?? "object";

                    if(propertyType is "Int64")
                    {
                        propertyType = "IntegerParameter";
                    }
                    if (propertyType is "Boolean")
                    {
                        propertyType = "BooleanParameter";
                    }
                    if (propertyType is "Double")
                    {
                        propertyType = "RealParameter";
                    }
                    if (propertyType is "String")
                    {
                        propertyType = "StringParameter";
                    }

                    string propertyEntry = $"   [Element(Identifier = \"{propertyName}\")]\n          internal {propertyType} {propertyName} {{ get; private set; }}";

                    if (!classDefinitions[parentClass].Contains(propertyEntry) && !existingDefinitions.Contains(propertyName))
                    {
                        classDefinitions[parentClass].Add(propertyEntry);
                        //existingDefinitions.Add(propertyName); // Track property definitions to prevent re-addition
                    }
                }
            }
        }

        public static void DisplayClasses()
        {
            Console.WriteLine($"   public sealed class AuronRoot : Root<AuronRoot>");
            Console.WriteLine("   {");
            Console.WriteLine($"       internal auron auron {{ get; private set; }}");
            Console.WriteLine("   }");

            foreach (var classDef in classDefinitions)
            {
                if (!uniqueClasses.Contains(classDef.Key)) continue; // Avoid duplicate class generation

                //Console.WriteLine($"   //---------------------------------------------------------------------");
                //Console.WriteLine($"   // {classDef.Key} class");
                //Console.WriteLine($"   //---------------------------------------------------------------------");
                Console.WriteLine($"   public sealed class {classDef.Key} : FieldNode<{classDef.Key}>");
                Console.WriteLine("   {");

                foreach (var property in classDef.Value)
                {
                    Console.WriteLine($"       {property}");
                }

                Console.WriteLine("   }");
                Console.WriteLine();
            }
        }











        //public static void GenerateClass(string className, Dictionary<string, string> properties)
        //{

        //    //classBuilder.AppendLine("using System;");
        //    //classBuilder.AppendLine($"public class {className}");
        //    //classBuilder.AppendLine("{");

        //    //for (int i = 0; i < properties.Count(); i++)
        //    //{
        //    //    var property = properties.ElementAt(i);
        //    //    classBuilder.AppendLine($"   Key: {property.Key}, Value: {property.Value} {{ get; set; }}");
        //    //}

        //    //classBuilder.AppendLine("}");


        //    //File.WriteAllText($"{className}.cs", classBuilder.ToString());       // Write the class to a file


        //    //for (int i = 0; i < properties.Count; i++)
        //    //{
        //    //    var property = properties.ElementAt(i);
        //    //    Console.WriteLine($"Key: {property.Key}, Value: {property.Value}");
        //    //}

        //}


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

                    //GenerateClassFile("test.cs");
                    DisplayClasses();
                    //GenerateClassFile
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
            //Console.WriteLine("\nDone. Press Enter to exit.");
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