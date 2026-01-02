namespace ToDoList_WebAPI
{
    public class TodoList
    {
        public Guid ID { get; private set; } = Guid.NewGuid();
        public string Title { get; set; }
        public bool IsDone { get; private set; }

        public TodoList(string t)
        {
            this.Title = t;
            this.IsDone = false;
        }

    }
}
