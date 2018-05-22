namespace UnsafeListx64
{
	public class UnsafeList<T> where T : class
	{
		const    int I = sizeof(long);
		readonly int _elementSize;
		T            _target = default(T);
		long[]       _storage;
		int          _currentIndex;
		readonly T[] _elements;
		readonly int _offset;

		public UnsafeList(int size, int elementSize)
		{
			_elementSize = elementSize + 1;
			_storage     = new long[size * _elementSize];
			_elements    = new T[size];

			_offset       = _elementSize * I;
			_currentIndex = -1;
		}

		public void Add(T item)
		{
			_currentIndex++;

			unsafe
			{
				var reference   = __makeref(item);
				var itemAddress = (long*)(*(long*)*(long*)&reference - I);

				for (long i = 1; i < _elementSize; ++i)
				{
					_storage[_currentIndex * _elementSize + i] = *itemAddress;
					itemAddress                                = itemAddress + 1;
				}

				reference                              = __makeref(_storage);
				_storage[_currentIndex * _elementSize] = *(long*)*(long*)&reference + _currentIndex * _offset + 32;
				_elements[_currentIndex]               = GetInternal(_currentIndex);
			}
		}

		public T this[int index] => _elements[index];

		T GetInternal(int index)
		{
			unsafe
			{
				var reference = __makeref(_target);
				*(long*)*(long*)&reference = _storage[index * _elementSize];
				var result = __refvalue(reference, T);
				return result;
			}
		}
	}
}