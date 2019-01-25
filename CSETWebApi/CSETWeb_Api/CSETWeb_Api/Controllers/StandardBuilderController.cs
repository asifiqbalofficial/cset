﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CSETWeb_Api.BusinessManagers;
using CSETWeb_Api.BusinessLogic.Models;
using CSETWeb_Api.Helpers;


namespace CSETWeb_Api.Controllers
{
    /// <summary>
    /// Houses all API calls used by the StandardBuilder logic.
    /// </summary>
    public class StandardBuilderController : ApiController
    {
        /// <summary>
        /// Returns a list of 'stock' standards, plus any custom standards
        /// owned by the current user.  Stock standards are marked as non-editable,
        /// while custom standards are editable.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/builder/GetCustomSets")]
        public List<SetDetail> GetCustomSetsList()
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.GetCustomSetList();
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Route("api/builder/GetSetDetail")]
        public SetDetail GetSetDetail([FromUri] string setName)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.GetSetDetail(setName);
        }


        /// <summary>
        /// Saves the set information and returns the setname (key) of the record.
        /// </summary>
        /// <param name="setDetail"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/builder/UpdateSetDetail")]
        public string UpdateSetDetail([FromBody]SetDetail setDetail)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.SaveSetDetail(setDetail);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/builder/CloneSet")]
        public SetDetail CloneSet([FromUri] string setName)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.CloneSet(setName);
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("api/builder/DeleteSet")]
        public void DeleteSet([FromBody] string setName)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            m.DeleteSet(setName);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Route("api/builder/GetQuestionsForSet")]
        public QuestionListResponse GetQuestionsForSet([FromUri] string setName)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            QuestionListResponse response = m.GetQuestionsForSet(setName);

            return response;
        }


        [HttpPost]
        [Route("api/builder/ExistsQuestionText")]
        public bool ExistsQuestionText([FromBody] string questionText)
        {
            // Don't let null be added as question text
            if (questionText == null)
            {
                return true;
            }

            StandardBuilderManager m = new StandardBuilderManager();
            return m.ExistsQuestionText(questionText);
        }


        /// <summary>
        /// Creates a new custom question from the supplied text.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        [Route("api/builder/AddCustomQuestion")]
        public void AddCustomQuestion([FromBody] SetQuestion request)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            m.AddCustomQuestion(request);
        }


        /// <summary>
        /// Adds a 'base' or 'stock' question to the Requirement or Set.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        [Route("api/builder/AddQuestion")]
        public void AddQuestion([FromBody] SetQuestion request)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            m.AddQuestion(request);
        }


        [HttpPost]
        [Route("api/builder/RemoveQuestion")]
        public void RemoveQuestion([FromBody] SetQuestion request)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            m.RemoveQuestion(request);
        }


        [HttpGet]
        [Route("api/builder/GetStandardCategories")]
        public List<CategoryEntry> GetStandardCategories()
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.GetStandardCategories();
        }


        [HttpGet]
        [Route("api/builder/GetCategoriesSubcategoriesGroupHeadings")]
        public CategoriesSubcategoriesGroupHeadings GetCategoriesSubcategoriesGroupHeadings()
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.GetCategoriesSubcategoriesGroupHeadings();
        }


        [HttpPost]
        [Route("api/builder/SearchQuestions")]
        public List<QuestionDetail> SearchQuestions([FromBody] QuestionSearch searchParms)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.SearchQuestions(searchParms);
        }


        [HttpPost]
        [Route("api/builder/SetSalLevel")]
        public void SetSalLevel([FromBody] SalParms parms)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            m.SetSalLevel(parms);
        }


        [HttpPost]
        [Route("api/builder/UpdateQuestionText")]
        public void UpdateQuestionText([FromBody] QuestionTextUpdateParms parms)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            m.UpdateQuestionText(parms.QuestionID, parms.QuestionText);
        }


        [HttpGet]
        [Route("api/builder/IsQuestionInUse")]
        public bool IsQuestionInUse([FromUri] int questionID)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.IsQuestionInUse(questionID);
        }


        [HttpPost]
        [Route("api/builder/UpdateHeadingText")]
        public void UpdateHeadingText([FromBody] HeadingUpdateParms parms)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            m.UpdateHeadingText(parms.PairID, parms.HeadingText);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Route("api/builder/GetStandardStructure")]
        public StandardsResponse GetStandardStructure([FromUri] string setName)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.GetStandardStructure(setName);
        }


        /// <summary>
        /// Creates a new Requirement.  Returns the ID.
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/builder/CreateRequirement")]
        public Requirement CreateRequirement([FromBody] Requirement parms)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.CreateRequirement(parms);
        }


        /// <summary>
        /// Returns the Requirement for the setname and requirement ID.
        /// </summary>
        /// <param name="setName"></param>
        /// <param name="reqID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/builder/GetRequirement")]
        public Requirement GetRequirement([FromUri] string setName, [FromUri] int reqID)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.GetRequirement(setName, reqID);
        }

        /// <summary>
        /// Updates an existing Requirement.
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/builder/UpdateRequirement")]
        public Requirement UpdateRequirement([FromBody] Requirement parms)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.UpdateRequirement(parms);
        }

        /// <summary>
        /// Removes an existing Requirement from the Set.
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/builder/RemoveRequirement")]
        public void RemoveRequirement([FromBody] Requirement parms)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            m.RemoveRequirement(parms);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/builder/GetReferenceDocs")]
        public List<ReferenceDoc> GetReferenceDocs([FromUri] string filter)
        {
            StandardBuilderManager m = new StandardBuilderManager();
            return m.GetReferenceDocs(filter);
        }

        /// <summary>
        /// Attaches or detaches a reference document from the set.
        /// </summary>
        [HttpPost]
        [Route("api/builder/SelectReferenceDoc")]
        public void SelectReferenceDoc()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/builder/UploadReferenceDoc")]
        public async Task<HttpResponseMessage> UploadReferenceDoc()
        {
            HttpRequestMessage request = this.Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string fileHash;
            try
            {
                var streamProvider = new InMemoryMultipartFormDataStreamProvider();
                await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(streamProvider);


                //access form data
                NameValueCollection formData = streamProvider.FormData;
                foreach (HttpContent ctnt in streamProvider.Files)
                {
                    // You would get hold of the inner memory stream here              
                    using (Stream fs = ctnt.ReadAsStreamAsync().Result)
                    {
                        string filename = ctnt.Headers.ContentDisposition.FileName.Trim("\"".ToCharArray());
                        string physicalFilePath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + @"\Documents\" + filename;
                        string contentType = ctnt.Headers.ContentType.MediaType;



                        // Do we support this file type?


                        string title = streamProvider.FormData["title"];


                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            using (FileStream fsw = File.Create(physicalFilePath, bytes.Length))
                            {
                                fsw.Write(bytes, 0, bytes.Length);
                            }




                            //// Hash the file so that we can determine if it is already attached to another question
                            //using (var md5 = MD5.Create())
                            //{
                            //    var hash = md5.ComputeHash(bytes);
                            //    fileHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                            //}

                            //// Find or create the Answer for the document to be associated with.  
                            //// If they are attaching a document to a question that has not yet been answered,
                            //// the answerId will not be sent in the request.
                            //int questionId = int.Parse(streamProvider.FormData["questionId"]);

                            //int answerId;
                            //bool isAnswerIdProvided = int.TryParse(streamProvider.FormData["answerId"], out answerId);
                            //string title = streamProvider.FormData["title"];

                            //if (!isAnswerIdProvided)
                            //{
                            //    QuestionsManager qm = new QuestionsManager(assessmentId);
                            //    Answer answer = new Answer();
                            //    answer.QuestionId = questionId;
                            //    answer.AnswerText = "U";
                            //    answerId = qm.StoreAnswer(answer);
                            //}
                            //var dm = new DocumentManager(assessmentId);
                            //using (CSETWebEntities db = new CSETWebEntities())
                            //{
                            //    dm.AddDocument(title, filename, contentType, fileHash, answerId, bytes);
                            //}

                            // Return a current picture of this answer's documents
                            return null; // Request.CreateResponse(dm.GetDocumentsForAnswer(answerId));
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }


            StandardBuilderManager m = new StandardBuilderManager();
            m.UploadReferenceDoc();


            return null;
        }
    }
}
