(function() {
    var navigationBarId = "#beersNavigation-col",
        submitFormWithQuaryPage1 = function() {
            $("#CurrentPageNumber", navigationBarId).val(1);
            submitNavigationForm();
        },
        initializeSearchByNameControls = function() {
            var $currentSearchNameValueHolder = $("#SearchName", navigationBarId),
                $searchBox = $("#searchByNameBox", navigationBarId),
                $submitBtn = $("#searchByNameBoxSubmitBtn", navigationBarId);
            $searchBox.val($currentSearchNameValueHolder.val());
            $submitBtn.click(function(event) {
                event.preventDefault();
                $currentSearchNameValueHolder.val($searchBox.val());
                submitFormWithQuaryPage1();
            });
        },
        initializeStyleFilter = function() {
            var $styleFilter = $("#Style", navigationBarId);
            $styleFilter.change(submitFormWithQuaryPage1);
        },
        initializeSortByFilter = function() {
            var $sortByFilter = $("#SortBy", navigationBarId);
            $sortByFilter.change(submitFormWithQuaryPage1);
        },
        pageNavigaionBtnClickEventHandler = function(eventTrigger, $currentPageValueHolder, i) {
            if (!$(eventTrigger).parent().hasClass("disabled")) {
                $currentPageValueHolder.val(parseInt($currentPageValueHolder.val()) + i);
                submitNavigationForm();
            }
        },
        initializePagingNavigation = function() {
            var $currentPageValueHolder = $("#CurrentPageNumber", navigationBarId),
                $previousPageBtn = $(".previousPage", navigationBarId),
                $nextPagePageBtn = $(".nextPage", navigationBarId);
            $previousPageBtn.click(function(event) {
                event.preventDefault();
                pageNavigaionBtnClickEventHandler(this, $currentPageValueHolder, -1);
            });
            $nextPagePageBtn.click(function(event) {
                event.preventDefault();
                pageNavigaionBtnClickEventHandler(this, $currentPageValueHolder, 1);
            });
        },
        initializeNavigationForm = function() {
            initializeSearchByNameControls();
            initializeStyleFilter();
            initializeSortByFilter();
            initializePagingNavigation();
        },
        submitNavigationForm = function() {
            var $navigationForm = $("form", navigationBarId);
            $.ajax(
                {
                    type: "POST",
                    url: $navigationForm.attr("action"),
                    data: $navigationForm.serialize(),
                    success: function(response) {
                        $("#indexContentHolder").html(response);
                        $("#Style", navigationBarId).selectpicker("render");
                        $("#SortBy", navigationBarId).selectpicker("render");
                        initializeNavigationForm();
                    }
                }
            );
        };

    $(document).ready(function() {
        initializeNavigationForm();
    });
})();