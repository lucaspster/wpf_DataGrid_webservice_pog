using System.ComponentModel;

namespace NoticiasWeb
{
    internal class BindingSource
    {
        private BindingList<Article> bindingList;
        private object p;

        public BindingSource(BindingList<Article> bindingList, object p)
        {
            this.bindingList = bindingList;
            this.p = p;
        }
    }
}