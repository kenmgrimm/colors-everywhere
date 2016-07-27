var tagXOffset = 220;
var tagYOffset = 110;
var dom;

function OnLoaded()
{
	(document.getElementById) ? dom = true : dom = false;
	
	$('input[type=radio][name=tag][value="*"]').prop('checked', true);
	
	$('input[type=radio][name=tag]').change(function() 
	{
        if (this.value == '*') $(".item-row").show();
        else
		{
			var filter = this.value;
            $(".item-row").each(function(index, element) {
				var visible = false;
				$(this).find(".item-row-tag").each(function(index, element) {
                    if ($(this).text() == filter) visible = true;
                });
                
				if (visible) $(this).show();
				else $(this).hide();
            });
		}
	});
	
	$(".item-row-content .button").click(function(){
		window.location.href = $(this).attr("href");
	});
	
	window.setInterval("UpdateTagsPosition()", 10);
}

function UpdateTagsPosition()
{
	if (dom && !document.all) 
	{
		document.getElementById("all-tags").style.top = window.pageYOffset + tagYOffset + "px";
		document.getElementById("all-tags").style.left = window.pageXOffset + window.innerWidth - tagXOffset + "px";
	}
	if (document.all) 
	{
		document.all["all-tags"].style.top = document.documentElement.scrollTop + tagYOffset + "px";
		document.all("all-tags").style.left = window.pageXOffset + window.innerWidth - tagXOffset + "px";
	}
}