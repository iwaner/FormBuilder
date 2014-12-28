$(document).ready(function () {

    var FormTemplate = Backbone.Model.extend({

        // Default attributes for the todo item.
        defaults: function () {
            return {
                FormTemplateId: "",
                FormDescription: "FormDescription",
                FormName: "FormName",
                CreateUser: "CreateUser",
                FormTemplateData: ""
            };
        },

        // Ensure that each todo created has `title`.
        initialize: function () {

        }

    });

    // FormTemplate Collection
    // ---------------
    var FormTemplateList = Backbone.Collection.extend({

        // Reference to this collection's model.
        model: FormTemplate
    });

    // Create our global collection of **FormTemplateList**.
    var FormTemplates = new FormTemplateList;

    // Todo Item View
    // --------------

    // The DOM element for a FormTemplate item...
    var FormTemplateView = Backbone.View.extend({

        //... is a tr tag.
        tagName: "tr",

        // Cache the template function for a single item.
        template: _.template($('#itemTemplate').html()),

        // The DOM events specific to an item.
        events: {
            "dblclick .gradeA": "edit"
        },

        // The TodoView listens for changes to its model, re-rendering. Since there's
        // a one-to-one correspondence between a **Todo** and a **TodoView** in this
        // app, we set a direct reference on the model for convenience.
        initialize: function () {
            this.listenTo(this.model, 'change', this.render);
            this.listenTo(this.model, 'destroy', this.remove);
        },

        // Re-render the titles of the todo item.
        render: function () {
            this.$el.html(this.template(this.model.toJSON()));
            return this;
        },

        // Switch this view into `"editing"` mode, displaying the input field.
        edit: function () {
   
        },

        // Remove the item, destroy the model.
        clear: function () {
            this.model.destroy();
        }

    });

    // The Application
    // ---------------

    // Our overall **AppView** is the top-level piece of UI.
    var FormTemplateListView = Backbone.View.extend({

        // Instead of generating a new element, bind to the existing skeleton of
        // the App already present in the HTML.
        el: $("#listContent"),

        // Our template for the line of statistics at the bottom of the app.
        statsTemplate: _.template($('#listContentTemplate').html()),

        // At initialization we bind to the relevant events on the `FormTemplates`
        // collection, when items are added or changed. Kick things off by
        // loading any preexisting FormTemplates that might be saved in *localStorage*.
        initialize: function () {
            this.listenTo(FormTemplates, 'add', this.addOne);
            this.listenTo(FormTemplates, 'reset', this.addAll);
            this.listenTo(FormTemplates, 'all', this.render);

            FormTemplates.fetch();
        },

        // Re-rendering the App just means refreshing the statistics -- the rest
        // of the app doesn't change.
        render: function () {
            var done = FormTemplates.done().length;
            var remaining = FormTemplates.remaining().length;

            if (FormTemplates.length) {
                this.main.show();
                this.footer.show();
                this.footer.html(this.statsTemplate({ done: done, remaining: remaining }));
            } else {
                this.main.hide();
                this.footer.hide();
            }

        },

        // Add a single todo item to the list by creating a view for it, and
        // appending its element to the `<ul>`.
        addOne: function (todo) {
            var view = new TodoView({ model: todo });
            this.$("#todo-list").append(view.render().el);
        },

        // Add all items in the **FormTemplates** collection at once.
        addAll: function () {
            FormTemplates.each(this.addOne, this);
        },

        // If you hit return in the main input field, create new **Todo** model,
        // persisting it to *localStorage*.
        createOnEnter: function (e) {
            if (e.keyCode != 13) return;
            if (!this.input.val()) return;

            FormTemplates.create({ title: this.input.val() });
            this.input.val('');
        },

        // Clear all done todo items, destroying their models.
        clearCompleted: function () {
            _.invoke(FormTemplates.done(), 'destroy');
            return false;
        },

        toggleAllComplete: function () {
            var done = this.allCheckbox.checked;
            FormTemplates.each(function (todo) { todo.save({ 'done': done }); });
        }

    });

    // Finally, we kick things off by creating the **App**.
    var FormTemplateListView = new FormTemplateListView;



    $('.dataTables-example').dataTable();

    /* Init DataTables */
    var oTable = $('#editable').dataTable();

    /* Apply the jEditable handlers to the table */
    oTable.$('td').editable('../example_ajax.php', {
        "callback": function (sValue, y) {
            var aPos = oTable.fnGetPosition(this);
            oTable.fnUpdate(sValue, aPos[0], aPos[1]);
        },
        "submitdata": function (value, settings) {
            return {
                "row_id": this.parentNode.getAttribute('id'),
                "column": oTable.fnGetPosition(this)[2]
            };
        },

        "width": "90%",
        "height": "100%"
    });


});

function fnClickAddRow() {
    $('#editable').dataTable().fnAddData([
                "Custom row",
                "New row",
                "New row",
                "New row",
                "New row"]);

}