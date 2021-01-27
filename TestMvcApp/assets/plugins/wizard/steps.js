$(".tab-wizard").steps({
    headerTag: "h6",
    bodyTag: "section",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: "Submit"
    },
    onFinished: function (event, currentIndex) {
        var form = $(this);
        // Submit form input
        form.submit();
    }
});


var form = $(".validation-wizard").show();

$(".validation-wizard").steps({
    headerTag: "h6"
    , bodyTag: "section"
    , transitionEffect: "fade"
    , titleTemplate: '<span class="step">#index#</span> #title#'
    , labels: {
        finish: "Submit"
    }
    ,
    onStepChanging: function (event, currentIndex, newIndex) {

        if (currentIndex == '0') {

            var regno = $('#txtRegNo').val();
            var chasisno = $('#txtChassisNo').val();
            var Engine = $('#txtEngineNo').val();
            var PolicyNo = $('#txtPolicyNo').val();

            var customer = $('#txtCustomer').val();
            var customerNo = $('#txtContactNo').val();
            if (customer == '' || customerNo == "") {
                form.valid()
            }
            else {

                if (regno == '' && chasisno == '' && Engine == '' && PolicyNo == '') {
                    swal('Please fill atleast 1 from Reg#, Eng#, Chassis# and Policy# fields');
                }
                else {
                    var PolicyStatus = CheckPolicyStatus();
                    return currentIndex > newIndex || !(3 === newIndex && Number($("#age-2").val()) < 18)
                        && (currentIndex < newIndex && (form.find(".body:eq(" + newIndex + ") label.error").remove(),
                            form.find(".body:eq(" + newIndex + ") .error").removeClass("error")),
                            form.validate().settings.ignore = ":disabled,:hidden", form.valid())
                }
            }
                
        }
        else {
            return currentIndex > newIndex || !(3 === newIndex && Number($("#age-2").val()) < 18) && (currentIndex < newIndex && (form.find(".body:eq(" + newIndex + ") label.error").remove(), form.find(".body:eq(" + newIndex + ") .error").removeClass("error")), form.validate().settings.ignore = ":disabled,:hidden", form.valid())

        }



      
    }
    , onFinishing: function (event, currentIndex) {
        return form.validate().settings.ignore = ":disabled", form.valid()
    }
    , onFinished: function (event, currentIndex) {
        swal("Form Submitted!", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lorem erat eleifend ex semper, lobortis purus sed.");
    }
}),


    $(".validation-wizard").validate({
    ignore: "input[type=hidden]"
    , errorClass: "text-danger"
    , successClass: "text-success"
    , highlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    }
    , unhighlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    }
    , errorPlacement: function (error, element) {
        error.insertAfter(element)
    }
    , rules: {
        email: {
            email: !0
        }
    }
})