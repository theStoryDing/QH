using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCommon
{
    /// <summary>
    /// 阻塞队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BlockQueue<T>
    {       
        private BlockingCollection<T> _blockQueue;
        private readonly int maxSize;

           
        public BlockQueue(int _maxSize)
        {
            maxSize = _maxSize;
            _blockQueue = new BlockingCollection<T>(maxSize);
        }

        ///<summary>
        ///往队列中添加数据
        /// </summary>
        public void Enqueue(T item)
        {
            _blockQueue.Add(item);
        }

        ///<summary>
        ///从队列中取数据(用于foreach)
        /// </summary>
        public IEnumerable<T> GetEnumerable()
        {
            return _blockQueue.GetConsumingEnumerable();
        }
        ///<summary>
        ///从队列中取数据
        /// </summary>
        public T Dequeue()
        {          
            return _blockQueue.Take();
        }



        ///<summary>
        ///获取队列内部元素的数量
        /// </summary>
        public int GetQueueItemCount { get { return _blockQueue.Count; } }

        ///<summary>
        ///禁止队列添加数据
        /// </summary>
        public void CompleteAdding()
        {
            _blockQueue.CompleteAdding();
        }

        ///<summary>
        ///队列中的元素是否处理完，为空集
        /// </summary>
        public bool IsCompleted { get { return _blockQueue.IsCompleted; } }

        public void Close()
        {
            _blockQueue.Dispose();
        }
        
    }
}
