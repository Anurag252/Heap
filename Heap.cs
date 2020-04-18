  class Heap
    {

        public int count = 0;
        private int capacity = 0;
        private int[] arr;


        public Heap(int count)
        {
            arr = new int[count];
        }

        public void print()
        {
            for ( var i = 0; i < count; i++ )
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        int GetLeft(int parent)
        {
            return parent == 0 ? 1 : parent * 2 + 1;
        }

        int GetRight(int parent)
        {
            return parent * 2 + 2;
        }

        int GetParent(int child)
        {
            return child % 2 == 0 ? child / 2 - 1 : child / 2;
        }

        public void PercolateDown(int i)
        {
            if ( i > count - 1 || i < 0 )
            {
                return;
            }
            int leftIndex = GetLeft(i);
            int rightIndex = GetRight(i);
            int max = -1;
            if ( leftIndex < count )
            {
                if ( arr[i] > arr[leftIndex] )
                {
                    max = i;
                }
                else
                {

                    max = leftIndex;
                }

            }

            if ( rightIndex < count && max > -1 )
            {
                if ( arr[max] < arr[rightIndex] )
                {
                    max = rightIndex;
                }
            }


            if ( max != i && max != -1 )
            {
                Sawp(arr, i, max);
                PercolateDown(max);
            }
        }

        public void Insert(int data)
        {
            count = arr.Length+1;
            var arr1 = new int[count];
            for ( int i = 0; i < arr.Length; i++ )
            {
                arr1[i] = arr[i];
            }

            arr1[count - 1] = data;
            arr = arr1;
            if ( count - 1 > 0 )
                PercolateUp(count - 1);
        }

        public void PercolateUp(int i)
        {
            if ( i > 0 )
            {
                int parent = GetParent(i);
                int left = GetLeft(parent);
                int right = GetRight(parent);
                int max = -1;
                if ( left < count && left > 0 )
                {
                    if ( arr[parent] < arr[left] )
                    {
                        max = left;
                    }
                    else
                    {
                        max = parent;
                    }
                }

                if ( right < count && right > 0 && max > -1 )
                {
                    if ( arr[max] < arr[right] )
                    {
                        max = right;
                    }
                }

                if ( max != parent )
                {
                    Sawp(arr, max, parent);

                }


                if ( max != parent && max > 0 )
                {
                    PercolateUp(GetParent(i));
                }
                else
                {
                    if ( parent > 0 )
                        PercolateUp(GetParent(i));
                }
            }


        }

        public int DeleteMax()
        {
            int data = arr[0];
            arr[0] = arr[count - 1];
            count = count - 1;
            PercolateDown(0);
            return data;
        }

        private void Sawp(int[] arr, int i, int max)
        {
            int temp = arr[i];
            arr[i] = arr[max];
            arr[max] = temp;
        }
    }

