var saludo = 'Hopla';
availableQueries = [];
    
function Expression() {
    this.size = 0;

    this.operations = 0;
    this.queries = [];
}
Expression.prototype.Format = function () {
    var res = '\n' + this.size + ' ' + this.operations;
    $.each(this.queries, function () {
        res += this.Format();
    });
    return res;
};

function Query(name) {
    this.name = name;
    this.values = [];
}
Query.prototype.Format = function () {
    var res = '\n' + this.name;
    $.each(this.values, function () {
        res += ' ' + this.Format();
    });
    return res;
};

function QueryValue(label, value) {
    this.label = label;
    this.value = value;
}
QueryValue.prototype.Format = function () {
    return (this.value);
};

$(document).ready(function (e) {
    
    var queryHTML = '<p class="basequery">';
    queryHTML += '<select class="queryvalue" id="borrar">';
    queryHTML += '<option value="0"></option>';
    $.each(availableQueries, function () {
        queryHTML += '<option value=' + this.name + '>' + this.name + '</option>';
    });
    queryHTML += '</select>';
    queryHTML += '<span class="queryHTMLValues"></span></p>';

    var queryValueHTML = '<input type="text" class="numvalue"/>';

    allExpressions = [];

    $('#btnexphelper').button({
        icons: {
            primary: "ui-icon-circle-plus"
        }
    }).click(function () {
        allExpressions = [];
        $('#expcount').val(0);
        expcount = 0;
        $('#new-exp').dialog('open');
    });

    $('#new-exp').dialog({
        modal: true,
        autoopen: false,
        draggable: true,
        resizable: false,
        closeOnEscape: true,
        width: "50%",
        buttons: {
            "Generate Expression": function () {
                expcount = parseInt($('#expcount').val()) + 1;
                $('#expcount').val(expcount.toString());
                var expression = new Expression();
                expression.size = $('#size').val();
                expression.operations = $('#opercount').val();

                $('.basequery').each(function () {
                    var query = $(this).find('.queryvalue').val();
                    var objQuery = new Query(query);
                    $(this).find('.numvalue').each(function () {
                        var objQueryValue = new QueryValue('', $(this).val());
                        objQuery.values.push(objQueryValue);
                    });
                    expression.queries.push(objQuery);
                });
                allExpressions[allExpressions.length] = expression;
                WriteExpToArea();
            },
            "OK": function () {
                $(this).dialog('close');
            }
        }
    });

    $('#opercount').keyup(function () {
        var queries = '';
        var opercount = $('#opercount').val();
        for (i = 0; i < opercount; i++) {
            queries += queryHTML;
        }
        $('#queries').html(queries);
    });

    $('#queries').on('change', '.queryvalue', function () {
        var basequery = $(this).parent('.basequery');
        var querySelected = $(this).val();
        var values = '';
        $.each(availableQueries, function () {
            if (this.name == querySelected) {
                $.each(this.values, function () {
                    values += ' ' + this.label + ' ' + queryValueHTML;
                });
            }
        });
        basequery.find('.queryHTMLValues').html(values);
    });

    function WriteExpToArea() {
        var exp = '';
        $.each(allExpressions, function () {
            exp += this.Format();
        });
        $('.taInput').val(expcount.toString() + exp);
    }

    // $('#new-exp').dialog('close');

}); // end ready