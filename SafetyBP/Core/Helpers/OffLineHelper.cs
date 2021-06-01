using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SafetyBP.Core.Interfaces;
using SafetyBP.Domain.Entities;
using SafetyBP.Domain.Interfaces.Helpers;
using SafetyBP.Domain.OperationsResult;
using SafetyBP.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SafetyBP.Core.Helpers
{
    public class OffLineHelper : IOffLineHelper
    {
        private readonly ICallApiHelper _callApiHelper;
        public OffLineHelper()
        {
            _callApiHelper = DependencyService.Get<ICallApiHelper>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task Add(OffLineRequest request)
        {
            using (var blogContext = new SafetyContext())
            {
                blogContext.OffLineRequests.Add(request);
                await blogContext.SaveChangesAsync();
            }
        }
        
        public int GetHashCode(string request) 
        {
            var comparer = new JTokenEqualityComparer();
            return comparer.GetHashCode(request);
        }

        public async Task Add(int requestId, string request, string url, string module) 
        {
            using (var blogContext = new SafetyContext())
            {
                var operationId = await GetOperation(module);
                
                var last = await blogContext.OffLineRequests.Where(wh => wh.OperationId == operationId).OrderBy(ob => ob.OrderId).LastOrDefaultAsync();
                
                short orderId = 1;
                if (last != null) orderId = (short)(last.OrderId + 1);

                await Add(new OffLineRequest()
                {
                    Request = request,
                    Url = url,
                    UserId = string.Empty,
                    RequestId = requestId,
                    OperationId = operationId,
                    OrderId = orderId
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public async Task Remove(int requestId)
        {
            using (var blogContext = new SafetyContext())
            {
                var request = await blogContext.OffLineRequests.FirstOrDefaultAsync(fo => fo.RequestId == requestId);
                if (request != null) 
                {
                    blogContext.OffLineRequests.Remove(request);
                    await blogContext.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task Synchronize(string userId)
        {
            using (var blogContext = new SafetyContext())
            {
                List<OffLineRequest> requests;

                try
                {
                    if (userId.Trim().Length == 0)
                    {
                        requests = await blogContext.OffLineRequests.OrderBy(ob => ob.Id).ToListAsync();
                    }
                    else
                    {
                        requests = await blogContext.OffLineRequests.Where(wh => wh.UserId == userId).ToListAsync();
                    }

                    if (requests != null)
                    {
                        foreach (var request in requests)
                        {
                            // Send the request and check out if it was sent.
                            var response = await _callApiHelper.SendRequest(request.Request, request.Url);

                            if (response.Result)
                            {
                                blogContext.OffLineRequests.Remove(request);
                                await blogContext.SaveChangesAsync();
                            }
                        }
                    }
                }
                catch (System.Exception ex) 
                { 
                
                }
                
            }
        }

        public async Task<int> BeginOperation(string module)
        {
            int result = 0;

            using (var blogContext = new SafetyContext())
            {
                result = await GetOperation(module);
                if (result == 0)
                {
                    blogContext.OffLineOperations.Add(new OffLineOperation() { Module = module });
                    await blogContext.SaveChangesAsync();
                    result = await GetOperation(module);
                }
                
            }

            return result;
        }

        public async Task CommitOperation(int operationId, Action<BooleanOperationResult> callback)
        {
            using (var blogContext = new SafetyContext())
            {
                List<OffLineRequest> requests;
                try
                {
                    requests = await blogContext.OffLineRequests.Where(wh => wh.OperationId == operationId).OrderBy(ob => ob.OrderId).ToListAsync();

                    bool isConnectionFast = DependencyService.Get<INetwork>().IsConnectedFast();
                    
                    if (requests != null)
                    {
                        foreach (var request in requests)
                        {
                            // Send the request and check out if it was sent.
                            if (isConnectionFast)
                            {
                                var response = await _callApiHelper.SendRequest(request.Request, request.Url);
                                if (response.Result)
                                {
                                    blogContext.OffLineRequests.Remove(request);
                                    await blogContext.SaveChangesAsync();
                                }
                            }                            
                        }
                    }

                    if (isConnectionFast)
                    {
                        // Remove the operation
                        var operation = await blogContext.OffLineOperations.Where(wh => wh.Id == operationId).FirstOrDefaultAsync();
                        if (operation != null)
                        {
                            blogContext.OffLineOperations.Remove(operation);
                            await blogContext.SaveChangesAsync();
                        }
                    }


                    callback?.Invoke(new BooleanOperationResult()
                    {
                        Result = true
                    });
                }
                catch (System.Exception ex)
                {
                    callback?.Invoke(new BooleanOperationResult()
                    {
                        Result = false,
                        Message = ex.Message
                    });
                }

            }
        }

        private async Task<int> GetOperation(string module)
        {
            int result = 0;
            using (var blogContext = new SafetyContext())
            {
                var last = await blogContext.OffLineOperations.Where(wh => wh.Module == module).OrderByDescending(ob => ob.Id).Take(1).LastOrDefaultAsync();
                if (last != null) result = last.Id;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string SerializateObject(object request) 
        { 
            return JsonConvert.SerializeObject(request);
        }

        public bool IsConnected() 
        {
            return (Connectivity.NetworkAccess == NetworkAccess.Internet);
        }
    }
}
