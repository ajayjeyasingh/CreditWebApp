$('.jumbo-option').click(function () {

    var selectedAnswer = $(this).find('div.jumbo-option-hidden').text();

    $('.jumbo-option').removeClass('selected');
    $(this).addClass('selected');
    
    $("#SelectedAnswer").val(selectedAnswer);

});