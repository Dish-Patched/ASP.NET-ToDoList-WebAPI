namespace ToDoList_WebAPI
{
    public class TodoList
    {
        public int ID { get; private set; } 
        public string Title { get; set; }
        public bool IsDone { get; private set; }

        public TodoList(string t, int Id)
        {
            this.ID = Id;
            this.Title = t;
            this.IsDone = false;
        }

        public void Done()
        {
            this.IsDone = true;
        }

    }
}
