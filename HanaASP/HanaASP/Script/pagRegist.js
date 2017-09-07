var TEXT = {
    SUBMIT: "Guardar",
    CANCEL: "Cancelar",
    NEXT: "Siguiente",
    PREVIOUS: "Atras",
    SAVE: "Guardar"
};

function ProgressForm(id, state, sendCallback, cancelCallback) {

    this.state = state || { currentPage: 0, data: {} };

    // DOM Elements
    this.gui = {};
    this.gui.form = document.getElementById(id);
    this.gui.footer = document.getElementsByTagName('footer')[0] || null;
    this.gui.header = document.getElementsByTagName('header')[0] || null;
    this.gui.pages = this.gui.form.getElementsByClassName('page');
    this.gui.inputs = this.gui.form.getElementsByTagName('input');
    this.gui.controls = {
        button: {
            back: this.gui.footer.getElementsByClassName('back')[0] || null,
            next: this.gui.footer.getElementsByClassName('advance')[0] || null
        }
    };
    for (var key in this.gui.pages) {
        this.gui.pages[key].inputs = this.gui.inputs;
    }
    this.gui.form.progressForm = this;

    // Callbacks & Event listeners
    var self = this;
    this.sendCallback = typeof sendCallback === 'undefined' ? function (form) {
        form.submit();
    } : sendCallback;
    this.cancelCallback = typeof cancelCallback === 'undefined' ? function (form) {
        form.reset();
    } : cancelCallback;

    this.gui.controls.button.back.addEventListener('click', function (event) {
        self.previousPage();
        event.preventDefault();
    }, false);
    this.gui.controls.button.next.addEventListener('click', function (event) {
        self.nextPage();
        event.preventDefault();
    }, false);

    for (n in this.gui.inputs) {
        if (this.gui.inputs[n].addEventListener)
            this.gui.inputs[n].addEventListener('keyup', function (event) {
                var key = event.target.getAttribute('name') || event.target.id,
                    val = event.target.value;
                self.state.data[key] = val;
                event.preventDefault();
            }, false);
    }
};
ProgressForm.prototype.nextPage = function () {
    if (this.getCurrentPage() + 1 == this.getNumPages()) return this.sendCallback(this.gui.form);
    this.setCurrentPage(this.getCurrentPage() + 1);
};
ProgressForm.prototype.previousPage = function () {
    if (this.getCurrentPage() == 0) return this.cancelCallback(this.gui.form);
    this.setCurrentPage(this.getCurrentPage() - 1);
};
ProgressForm.prototype.setCurrentPage = function (c) {
    if (typeof c === 'undefined') return;
    var n = this.getNumPages();
    this.state.currentPage = ((c % n) + n) % n;
    this.updateView();
};
ProgressForm.prototype.getPages = function () { return this.gui.pages.length ? this.gui.pages : this.fetchPages(); };
ProgressForm.prototype.getCurrentPage = function () {
    var c = this.state.currentPage,
        n = this.getNumPages();
    return ((c % n) + n) % n;
};
ProgressForm.prototype.getNumPages = function () {
    if (typeof this.state.numPages === 'undefined') this.state.numPages = this.getPages().length;
    return this.state.numPages;
};
ProgressForm.prototype.fetchPages = function () { return document.getElementById('.page'); };
ProgressForm.prototype.updateView = function () {
    var n = this.getCurrentPage();
    this.gui.form.setAttribute('class', 'page-' + n);
    this.gui.controls.button.next.textContent = (n == this.getNumPages() - 1) ? TEXT.SUBMIT : TEXT.NEXT;
    this.gui.controls.button.back.textContent = n === 0 ? TEXT.CANCEL : TEXT.PREVIOUS;
};


var frm = new ProgressForm('pag');

/*
Old event handling system
this.events = [
  {
    action: 'dbclick',
    trigger: this.gui.controls.button.back,
    callback: function(e) { self.previousPage(); }
  },
  {
    action: 'click',
    trigger: this.gui.controls.button.next,
    callback: function(e) { self.nextPage(); }
  }
];

for(n in this.events) {
  var action = self.events[n].action;
  var trigger = self.events[n].trigger;
  var callback = self.events[n].callback;
  trigger.addEventListener(action, function(event) {
    var dispatchedEvent = new Event(action, {
      'view': window,
      'action': action,
      'trigger': trigger,
      'callbackName': callback,
    });
    event.preventDefault();
   // self.gui.form.dispatchEvent(dispatchedEvent);
    //console.log(callback)
    callback();
    console.log(callback.toString())
    return false;
  }, false);
}
*/