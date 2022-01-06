
/*User güncelleme*/
$(".updateUserRecord").on("click", function () {
    var $form = $("#updateUser")
    var name = $form.find("#Name").val()
    var lastName = $form.find("#LastName").val()
    var eMail = $form.find("#Email").val()
    var password = $form.find("#Password").val()
    var birthday = $form.find("#Birthday").val()
    var userId = $form.find("#UserId").val()
    var url = "/settings/UpdateUser/" + UserId;
    $.ajax({
        url: url,
        type: "POST",
        data: { name: name, lastName: lastName, eMail: eMail, password: password, birthday: birthday, userId: userId },
        success: function (gelenveri) {
            Swal.fire({
                title: gelenveri,
                icon: 'success'
            }).then(function (neyeBasildi) {
                window.location = "/setting/index/";
            })
        },
        error: function (error) {
            Swal.fire({
                title: error,
                icon: 'error'
            })
        }
    })
});


/*User kayıt etme*/
$("#userRegisterBtn").on("click", function () {
    var $form = $("#userRegisterForm")
    var name = $form.find("#Name").val()
    var lastName = $form.find("#LastName").val()
    var eMail = $form.find("#EMail").val()
    var password = $form.find("#Password").val()
    var birthday = $form.find("#Birthday").val()
    var url = "/login/RegisterUser/";
    $.ajax({
        url: url,
        type: "POST",
        data: { Name: name, LastName: lastName, Birthday: birthday, EMail: eMail, Password: password },
        success: function (gelenveri) {
            Swal.fire({
                title: gelenveri,
                icon: 'success'
            }).then(function (neyeBasildi) {
                window.location = "/login/index/";
            })
        },
        error: function (error) {
            Swal.fire({
                title: error,
                icon: 'error'
            })
        }
    })
});



///*Contact güncelleme*/
//$(".updateContactRecord").on("click", function () {
//    var $form = $("#updateContact")
//    var name = $form.find("#Name").val()
//    var lastName = $form.find("#LastName").val()
//    var eMail = $form.find("#Email").val()
//    var birthday = $form.find("#Birthday").val()
//    var contactId = $form.find("#UserId").val()
//    var url = "/Contact/UpdateContact/" + ContactId;
//    $.ajax({
//        url: url,
//        type: "POST",
//        data: { name: name, lastName: lastName, eMail: eMail, password: password, birthday: birthday, contactId: contactId },
//        success: function (gelenveri) {
//            Swal.fire({
//                title: gelenveri,
//                icon: 'success'
//            }).then(function (neyeBasildi) {
//                window.location = "/Contact/index/";
//            })
//        },
//        error: function (error) {
//            Swal.fire({
//                title: error,
//                icon: 'error'
//            })
//        }
//    })
//});

/*Contact silme*/
$(".deleteRecord").on("click", function () {
    var ContactId = $(this).data("model-id");
    var url = "/Contact/DeleteContact/" + ContactId;
    $.ajax({
        url: url,
        type: "POST",
        success: function (gelenveri) {
            Swal.fire({
                title: gelenveri,
                icon: 'success'
            }).then(function (neyeBasildi) {
                location.reload()
            })
        },
        error: function (error) {
            console.log(error.status)
        }
    })
});

/*Geri dön*/
$(".goBack").on("click", function (e) {
    e.preventDefault();
    window.history.back();
});

/*Kişi Arama/Search girişi*/
$(document).ready(function () {
    $("#searchInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#search_Input tr td:first-child").filter(function () {
            $(this).closest("tr").toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});


/*Contact Group Dropdown*/
function doNavigate() {
    window.location.href = document.getElementById("urlList").value;
}

/*Login Formu Temizleme ve mesajı saklama*/
document.addEventListener('loginForm', function (event) {
    event.preventDefault();
    event.target.reset();
});

$(document).keyup('loginForm', function (event) {
    $("#loginViewBag").hide();
});
//----------------------------------------//
document.addEventListener('updateContact', function (event) {
    event.preventDefault();
    event.target.reset();
});
$(document).keyup('updateContact', function (event) {
    $("#contactUpdateViewBag").hide();
});
//----------------------------------------//
document.addEventListener('newContact', function (event) {
    event.preventDefault();
    event.target.reset();
});
$(document).keyup('newContact', function (event) {
    $("#newContactViewBag").hide();
});
//----------------------------------------//
document.addEventListener('formMailToContact', function (event) {
    event.preventDefault();
    event.target.reset();
});
$(document).keyup('formMailToContact', function (event) {
    $("#sendMailViewBag").hide();
});


//$('#urlList').on("change", function () {
//    var selected = $(this).val("urlList"); // get selected value from dropdown
//    var Url = "/Contact/GetResults/";
//    //var param = $(this).find('option:selected').attr('groupId');
//    var param = { groupId: selected };

//    $.ajax({
//        url: Url,
//        type: 'GET',
//        data: param,
//        dataType: 'json',
//        success: function (response) {
//            var row = '';
//            for (var i = 0; i < response.length; i++) {
//                row += '<tr><td>' + response[i].name + '</td><td>' + response[i].lastName + '</td><td>' + response[i].birthday + '</td><td>' + response[i].eMail + '</td></tr>';
//                $('#contactTable tbody').append(row);
//            }
//        }
//    });
//});




//Scheduler page

$(function () {
    if ($('#scheduler').length > 0) {
        function getData() {
            const url = "/Calender/GetContacts/";
            $.ajax({
                url: url,
                type: "GET",
                success: function (gelenVeri) {
                    //console.log("getData:", gelenVeri);
                    const scheduler = $("#scheduler").data("kendoScheduler");
                    if (scheduler !== undefined) {
                        scheduler.destroy()
                        $('.k-scheduler-toolbar').remove();
                    }
                    createScheduler(gelenVeri.task, gelenVeri.contact);
                },
                error: function (error) {
                    console.log(error);
                }
            })
        }

        const deleteTask = (taskId) => {
            var url = "/Calender/DeleteTask/?taskId=" + taskId;
            $.ajax({
                url: url,
                type: "POST",
                success: function (gelenveri) {
                    console.log(gelenveri)
                },
                error: function (error) {
                    console.log(error.status)
                }
            })
        }

        const createScheduler = (eventData, users) => {
            const formatedEventData = eventData.map(item => {
                return {
                    taskId: item.taskId,
                    title: item.taskTitle,
                    start: item.taskStart,
                    end: item.taskEnd,
                    recurrenceRule: item.recurrenceRule,
                    user: item.taskUser,
                    description: item.description
                }
            });

            const formatedUserData = users.map(user => {
                const userData = {
                    text: `${user.name} ${user.lastName}`,
                    value: user.contactId
                }
                return userData
            });

            kendo.culture("tr-TR");
            kendo.ui.progress($("#scheduler"), false);
            $("#scheduler").kendoScheduler({
                date: new Date(),
                startTime: new Date("2021/1/1 07:00 AM"),
                height: '100%',
                allDaySlot: false,
                timezone: "UTC",
                views: [
                    "day",
                    { type: "week", selected: true },
                    "workWeek",
                    "month"
                ],
                dataSource: {
                    data: formatedEventData,
                    schema: {
                        model: {
                            id: "taskId",
                            fields: {
                                taskId: { type: "number" },
                                title: { validation: { required: true } },
                                start: { type: "date" },
                                end: { type: "date" },
                                description: { type: "text" },
                                recurrenceRule: { field: "recurrenceRule" },
                                user: { validation: { required: true } }
                            }
                        }
                    }
                },
                resources: [
                    {
                        field: "user",
                        title: "Kişiler",
                        dataSource: formatedUserData
                    }
                ],
                save: function (item) {
                    const url = "/Calender/GetCalenderOperation/";
                    const startDate = new Date(item.event.start.setHours(item.event.start.getHours() + 6));
                    const endDate = new Date(item.event.end.setHours(item.event.end.getHours() + 6));
                    const sendData = {
                        taskId: item.event.taskId,
                        taskTitle: item.event.title,
                        taskStart: startDate.toISOString().slice(0, 19).replace('T', ' '),
                        taskEnd: endDate.toISOString().slice(0, 19).replace('T', ' '),
                        taskuser: item.event.user,
                        recurrenceRule: item.event.recurrenceRule,
                        description: item.event.description,
                    }
                    //console.log("sendData:", sendData);
                    $.ajax({
                        url: url,
                        type: "POST",
                        data: sendData,
                        success: function (gelenveri) {
                            console.log("Eklendi veya güncellendi");
                            getData();
                        },
                        error: function (error) {
                            console.log(error);
                        }
                    })
                },
                remove: function (item) {
                    deleteTask(item.event.taskId)
                }
            });
        }

        getData()
    }
})
