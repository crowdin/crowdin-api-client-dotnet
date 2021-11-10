/*
 * Crowdin API v2
 *
 *  # Introduction Welcome to Crowdin API v2 documentation.  Our API is a full-featured RESTful API that helps you to integrate localization into your development process. The endpoints that we use allow you to easily make calls to retrieve information and to execute actions needed.  Most of the functionality of Crowdin is available through the API. It allows you to create projects for translations, add and update files, download translations, and much more. In this way, you can script the complex actions that your situation requires.  Documentation starts with a general overview of the design and technology that was implemented and is followed by detailed information on specific methods and endpoints.  ## Asynchronous Operations Methods such as report generation, project build, and file download need some time to be completed and are finalized in several steps. It is what we call asynchronous operations. This  approach allows the application to work without interruptions while the method is running at the background.  To run asynchronous operations, 3 subsequent API methods are used:  *     Method to start operation – returns the status __Found__ if the resource you’re requesting is already generated. Typically, __201 Accepted__ status is returned along with the operation identifier. The operation status is then checked with the help of this identifier.  *     Method to check the status of operation – returns  the completion percentage.  *     Method to get the temporary link for resource download – mostly used for export operations. When the operation is completed, you can run this method to get a temporary link for resource download.  __Note:__ Download link is active for a few minutes.  For example, to download a Translation Memory (TM), you need to run following sequence of API methods:  *     [_Export TM_](#operation/api.tms.exports.post)  *     [_Check TM Export Status_](#operation/api.tms.exports.get)  *     [_Download TM_](#operation/api.tms.exports.getMany)  ## File Upload With Crowdin API v2 all files such as files for localization, screenshots, Glossaries, and Translation Memories should be first uploaded to the [Storage](#tag/Storage). After you upload file to the Storage it will have a unique storage id using which you can then add the file to the project.  For example, to upload a localization file to your project, you need to run the following sequence of API methods:  *     [_Add Storage_](#operation/api.storages.post) – upload localization file body to storage at Crowdin server  *     [_Add File_](#operation/api.projects.files.post) – define where to add the localization file with specific _storage id_  ## Authorization To work with Crowdin API v2 generate the personal access token by going to __Crowdin Account Settings > API & SSO > New Token__  Make sure to use the following __header__ in your requests:  `Authorization: Bearer ACCESS_TOKEN`  Responses in case authorization fail:  __401 Unauthorized__ ``` {   \"error\": {     \"message\": \"Unauthorized\",     \"code\": 401   } } ```  __403 Forbidden__ ``` {   \"error\": {     \"message\": \"Not allowed endpoint for token scopes\",     \"code\": 403   } } ``` ``` {   \"error\": {     \"message\": \"Not allowed space for your token\",     \"code\": 403   } } ```  ## Requests All requests should be made using the HTTPS protocol so that traffic is encrypted. The interface responds to different methods depending on the action required.  When a request is successful, a response will typically be sent back in the form of a JSON object. If you specify `Accept` header response will be `application/json`. It’s not required to specify `Accept` header so you can leave it empty.  The API expects all writing requests (_POST_, _PUT_, _PATCH_) in JSON format with the `Content-Type: application/json` header. This ensures that your request is interpreted correctly.  __Note:__ `Content-Type` header can be different (e.g. `image/jpeg`, `text/csv`) if you upload the file using _POST_ methods with a specified content type.  RESTful APIs enable you to call individual API endpoints to perform the following requests:  *     <span class='http-method method-list get'>GET</span> - for simple retrieval of information about source files, translations, or projects. The information you request will be returned to you as a JSON object. The attributes defined by the JSON object can be used to form additional requests.  *     <span class='http-method method-list post'>POST</span> - to create or add a new element. This request includes all of the attributes necessary to create a new object.  *     <span class='http-method method-list put'>PUT</span> - to update or replace the specific element. This request sets the state of the target using the provided values, regardless of their current values.  *     <span class='http-method method-list patch'>PATCH</span> - to edit some specific fields of an entity. With these requests, you only need to provide the data you want to change.  *     <span class='http-method method-list delete'>DELETE</span> - to remove element from your account. Request works if specified object is found. If it is not found, the operation will return a response indicating that the object was not found.  For example, to edit the name and description of a project, where the requested resource is the project with `id` = 1, the request is the following:  __Example Endpoint__ <div class='well well-sm'> <span class='http-method patch'>PATCH</span> https://api.crowdin.com/api/v2/<span class='api-section-block-highlighted'>projects/1</span> </div>  where <span class='api-section-block-highlighted'>projects/1</span> is the requested resource.  __Content-Type header:__ `application/json`  __Request body__ ``` [   {\"op\":\"replace\", \"path\":\"/name\", \"value\":\"Project new name\"},   {\"op\":\"replace\", \"path\":\"/description\", \"value\":\"New description for the project\"} ] ```  ## Rate Limits The number of simultaneous API requests per account is 20 requests. Response code __429 Too Many Requests__ is returned when the limit is exceeded.  ## Crowdin API Clients The Crowdin API clients are the lightweight interfaces developed for the Crowdin API v2. They provide common services for making API requests.  You may find detailed information on each client in its respective GitHub repository:  [_Crowdin JavaScript client_](https://github.com/crowdin/crowdin-api-client-js)\\ [_Crowdin PHP client_](https://github.com/crowdin/crowdin-api-client-php)\\ [_Crowdin Java client_](https://github.com/crowdin/crowdin-api-client-java)\\ [_Crowdin Python client_](https://github.com/crowdin/crowdin-api-client-python)\\ _Crowdin .NET client_ _(Coming soon)_  
 *
 * The version of the OpenAPI document: 2.0
 * Contact: support@crowdin.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;

namespace Crowdin.Api.Client
{
    /// <summary>
    /// A dictionary in which one key has many associated values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key</typeparam>
    /// <typeparam name="TValue">The type of the value associated with the key.</typeparam>
    public class Multimap<TKey, TValue> : IDictionary<TKey, IList<TValue>>
    {
        #region Private Fields

        private readonly Dictionary<TKey, IList<TValue>> _dictionary;

        #endregion Private Fields

        #region Constructors

        /// <summary>
        /// Empty Constructor.
        /// </summary>
        public Multimap()
        {
            _dictionary = new Dictionary<TKey, IList<TValue>>();
        }

        /// <summary>
        /// Constructor with comparer.
        /// </summary>
        /// <param name="comparer"></param>
        public Multimap(IEqualityComparer<TKey> comparer)
        {
            _dictionary = new Dictionary<TKey, IList<TValue>>(comparer);
        }

        #endregion Constructors

        #region Enumerators

        /// <summary>
        /// To get the enumerator.
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<KeyValuePair<TKey, IList<TValue>>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        /// <summary>
        /// To get the enumerator.
        /// </summary>
        /// <returns>Enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        #endregion Enumerators

        #region Public Members
        /// <summary>
        /// Add values to Multimap
        /// </summary>
        /// <param name="item">Key value pair</param>
        public void Add(KeyValuePair<TKey, IList<TValue>> item)
        {
            if (!TryAdd(item.Key, item.Value))
                throw new InvalidOperationException("Could not add values to Multimap.");
        }

        /// <summary>
        /// Add Multimap to Multimap
        /// </summary>
        /// <param name="multimap">Multimap</param>
        public void Add(Multimap<TKey, TValue> multimap)
        {
            foreach (var item in multimap)
            {
                if (!TryAdd(item.Key, item.Value))
                    throw new InvalidOperationException("Could not add values to Multimap.");
            }
        }

        /// <summary>
        /// Clear Multimap
        /// </summary>
        public void Clear()
        {
            _dictionary.Clear();
        }

        /// <summary>
        /// Determines whether Multimap contains the specified item.
        /// </summary>
        /// <param name="item">Key value pair</param>
        /// <exception cref="NotImplementedException">Method needs to be implemented</exception>
        /// <returns>true if the Multimap contains the item; otherwise, false.</returns>
        public bool Contains(KeyValuePair<TKey, IList<TValue>> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Copy items of the Multimap to an array,
        ///     starting at a particular array index.
        /// </summary>
        /// <param name="array">The array that is the destination of the items copied
        ///     from Multimap. The array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="NotImplementedException">Method needs to be implemented</exception>
        public void CopyTo(KeyValuePair<TKey, IList<TValue>>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified item from the Multimap.
        /// </summary>
        /// <param name="item">Key value pair</param>
        /// <returns>true if the item is successfully removed; otherwise, false.</returns>
        /// <exception cref="NotImplementedException">Method needs to be implemented</exception>
        public bool Remove(KeyValuePair<TKey, IList<TValue>> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the number of items contained in the Multimap.
        /// </summary>
        public int Count => _dictionary.Count;

        /// <summary>
        /// Gets a value indicating whether the Multimap is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an item with the provided key and value to the Multimap.
        /// </summary>
        /// <param name="key">The object to use as the key of the item to add.</param>
        /// <param name="value">The object to use as the value of the item to add.</param>
        /// <exception cref="InvalidOperationException">Thrown when couldn't add the value to Multimap.</exception>
        public void Add(TKey key, IList<TValue> value)
        {
            if (value != null && value.Count > 0)
            {
                if (_dictionary.TryGetValue(key, out var list))
                {
                    foreach (var k in value) list.Add(k);
                }
                else
                {
                    list = new List<TValue>(value);
                    if (!TryAdd(key, list))
                        throw new InvalidOperationException("Could not add values to Multimap.");
                }
            }
        }

        /// <summary>
        /// Determines whether the Multimap contains an item with the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the Multimap.</param>
        /// <returns>true if the Multimap contains an item with
        ///     the key; otherwise, false.</returns>
        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Removes item with the specified key from the Multimap.
        /// </summary>
        /// <param name="key">The key to locate in the Multimap.</param>
        /// <returns>true if the item is successfully removed; otherwise, false.</returns>
        public bool Remove(TKey key)
        {
            return TryRemove(key, out var _);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified key, if the
        ///     key is found; otherwise, the default value for the type of the value parameter.
        ///     This parameter is passed uninitialized.</param>
        /// <returns> true if the object that implements Multimap contains
        ///     an item with the specified key; otherwise, false.</returns>
        public bool TryGetValue(TKey key, out IList<TValue> value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets or sets the item with the specified key.
        /// </summary>
        /// <param name="key">The key of the item to get or set.</param>
        /// <returns>The value of the specified key.</returns>
        public IList<TValue> this[TKey key]
        {
            get => _dictionary[key];
            set => _dictionary[key] = value;
        }

        /// <summary>
        /// Gets a System.Collections.Generic.ICollection containing the keys of the Multimap.
        /// </summary>
        public ICollection<TKey> Keys => _dictionary.Keys;

        /// <summary>
        /// Gets a System.Collections.Generic.ICollection containing the values of the Multimap.
        /// </summary>
        public ICollection<IList<TValue>> Values => _dictionary.Values;

        /// <summary>
        ///  Copy the items of the Multimap to an System.Array,
        ///     starting at a particular System.Array index.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the items copied
        ///     from Multimap. The System.Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            ((ICollection)_dictionary).CopyTo(array, index);
        }

        /// <summary>
        /// Adds an item with the provided key and value to the Multimap.
        /// </summary>
        /// <param name="key">The object to use as the key of the item to add.</param>
        /// <param name="value">The object to use as the value of the item to add.</param>
        /// <exception cref="InvalidOperationException">Thrown when couldn't add value to Multimap.</exception>
        public void Add(TKey key, TValue value)
        {
            if (value != null)
            {
                if (_dictionary.TryGetValue(key, out var list))
                {
                    list.Add(value);
                }
                else
                {
                    list = new List<TValue> { value };
                    if (!TryAdd(key, list))
                        throw new InvalidOperationException("Could not add value to Multimap.");
                }
            }
        }

        #endregion Public Members

        #region Private Members

        /**
         * Helper method to encapsulate generator differences between dictionary types.
         */
        private bool TryRemove(TKey key, out IList<TValue> value)
        {
            _dictionary.TryGetValue(key, out value);
            return _dictionary.Remove(key);
        }

        /**
         * Helper method to encapsulate generator differences between dictionary types.
         */
        private bool TryAdd(TKey key, IList<TValue> value)
        {
            try
            {
                _dictionary.Add(key, value);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }
        #endregion Private Members
    }
}
