using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the context to the SharePoint site

             ClientContext context =   new ClientContext("http://sfdpmt02/");

               // The SharePoint web at the URL.                                    
             Web web = context.Web;

               // Get the list template by name
             ListTemplate listTemplate = web.ListTemplates.GetByName("Promoted Links");
             context.Load(listTemplate);

               // Execute the query to the server                                       
             context.ExecuteQuery();

               // Create a new object for ListCreationInformation class - used to specify the properties of the new list     
             ListCreationInformation creationInfo =   new ListCreationInformation();

               // Specify the promoted links list title                       
             creationInfo.Title =   "Custom Promoted Links";

               // Specify the promoted links list description               
             creationInfo.Description =   "My Custom Promoted Link List";

               // Set a value that specifies the feature identifier of the feature that contains the list schema for the new list.    
             creationInfo.TemplateFeatureId = listTemplate.FeatureId;

               // Set a value that specifies the list server template of the new list    
             creationInfo.TemplateType = listTemplate.ListTemplateTypeKind;

               // Add the new task list to the list collection
             web.Lists.Add(creationInfo);

               // Execute the query to the server                 
             context.ExecuteQuery();

        }
    }
}
