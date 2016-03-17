using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    interface Imodel_rules
    {
        List<model_category> Categories { get; }
        int NumberOfDice { get; }
        void checkPossibleCategories(List<model_die> dice);
        List<int> calculation(List<model_die> dice, int categoryId);
        void bonus(model_column column);
        void finished(model_column column);
        void loadCategories();
        model_column getColumn();
    }
}
