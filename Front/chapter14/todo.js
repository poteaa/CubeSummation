$(document).ready(function(e) {
	$('#todo-list').on('click', '.done', function() {
		var $taskItem = $(this).parent('li');
		$taskItem.slideUp(250, function() {
			var $this = $(this);
			$this.detach();
			$('#completed-list').prepend($this);
			$this.slideDown();
		});
		$('.sortlist').sortable({
			connectWith : '.sortlist',
			cursor : 'pointer',
			placeholder : 'ui-state-highlight',
			cancel : '.delete,.done,.task'
		});
	});
	$('.sortlist').on('click', '.delete', function() {
		$(this).parent('li').effect('puff', function() {
			$(this).remove();
		});
	});
	$('#add-todo').button({
		icons: {
			primary: "ui-icon-circle-plus"
		}
	}).click(function () {
		$('#new-todo').dialog('open');
	});
	$('#new-todo').dialog({
		modal : true,
		autoopen : false,
		draggable : true,
		resizable : true,
		buttons: {
			"Add task" : function() {
				var taskName = $('#task').val();
				if(taskName === '') {
					return false;
				}
				var taskHTML = '<li><span class="done">%</span>';
				taskHTML += '<span class="delete">x</span>';
				taskHTML += '<span class="task" contentEditable>></span></li>';
				// Or dynamically: $('.task').prop('contentEditable', true);
				var $newTask = $(taskHTML);
				$newTask.find('.task').text(taskName);
				$newTask.hide();
				$('#todo-list').prepend($newTask);
				$newTask.show('clip',250).effect('highlight',1000);
				$(this).dialog('close');
			},
			"Cancel" : function(){
				$(this).dialog('close');
			}
		},
		close: function() {
			$('#new-todo input').val('');
		}
	});
	$('#save-todo').click(function() {
		var data = getData();
		$.post('task/SaveTask', data, function() {
			
		});
	});
	function getData() {
		var todoData = {
		toDo : [],
		completed : []
		};
		$('#todo-list li').each( function() {
		var task = $(this).find('.task').text();
		todoData.toDo.push(task);
		});
		$('#completed-list li').each( function() {
		var task = $(this).find('.task').text();
		todoData.completed.push(task);
		});
		return $.param(todoData);
	}
}); // end ready