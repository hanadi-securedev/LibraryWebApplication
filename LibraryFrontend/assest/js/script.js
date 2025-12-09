/* BOOK JAVASCRIPT */
let add = document.querySelector(".btn-add");
let grid = document.querySelector(".books-grid");
let input = document.querySelector("#BookNAME");
let input1 = document.querySelector("#BookAuthor");
let input2 = document.querySelector("#BookISBN");
let input3 = document.querySelector("#BookPublisher")
let input4 = document.querySelector("#BookYear");
let input5 = document.querySelector("#BookGener");

add.addEventListener("click", function (e) {

    e.preventDefault();

    uservalue = input.value;
    uservalue1 = input1.value;
    uservalue2 = input2.value;
    uservalue3 = input3.value;
    uservalue4 = input4.value;
    uservalue5 = input5.value;

    if (uservalue != "") {

        let bookCard = document.createElement("div");
        bookCard.classList.add("book-card");
        /*
        creat book header
        */
        let bookheader = document.createElement("div");
        bookheader.classList.add("book-header");
        let div = document.createElement("div");

        let booktitle = document.createElement("h3");
        booktitle.classList.add("book-title");
        booktitle.textContent = uservalue

        let bookauthor = document.createElement("p");
        bookauthor.classList.add("book-author");
        bookauthor.textContent = uservalue1;

        let bookisbn = document.createElement("p");
        bookisbn.classList.add("book-isbn");
        bookisbn.textContent = uservalue2;

        let availabil = document.createElement("span")
        availabil.classList.add("availability-badge", "available")
        availabil.textContent = "Available";
        div.appendChild(booktitle);
        div.appendChild(bookauthor);
        div.appendChild(bookisbn)
        bookheader.appendChild(div);
        bookheader.appendChild(availabil);
        bookCard.appendChild(bookheader);
        /*
        end creat book header
        */


        /*
        creat book details
        */

        let bookdetail = document.createElement("div");
        bookdetail.classList.add("book-detail");

        let detailrow = document.createElement("div");
        detailrow.classList.add("detail-row");

        let detaillabel = document.createElement("span");
        detaillabel.classList.add("detail-label")
        detaillabel.textContent = "Publisher:";

        let detailvalue = document.createElement("span");
        detailvalue.classList.add("detail-value");
        detailvalue.textContent = uservalue3

        detailrow.appendChild(detaillabel)
        detailrow.appendChild(detailvalue)

        let detailrow1 = document.createElement("div");
        detailrow1.classList.add("detail-row");

        let detaillabel1 = document.createElement("span");
        detaillabel1.classList.add("detail-label")
        detaillabel1.textContent = "Year:";

        let detailvalue1 = document.createElement("span");
        detailvalue1.classList.add("detail-value");
        detailvalue1.textContent = uservalue4

        detailrow1.appendChild(detaillabel1)
        detailrow1.appendChild(detailvalue1)


        let detailrow2 = document.createElement("div");
        detailrow2.classList.add("detail-row");

        let detaillabel2 = document.createElement("span");
        detaillabel2.classList.add("detail-label")
        detaillabel2.textContent = "Genre:";

        let detailvalue2 = document.createElement("span");
        detailvalue2.classList.add("detail-value");
        detailvalue2.textContent = uservalue5

        detailrow2.appendChild(detaillabel2)
        detailrow2.appendChild(detailvalue2)



        bookdetail.appendChild(detailrow)
        bookdetail.appendChild(detailrow1)
        bookdetail.appendChild(detailrow2)
        bookCard.appendChild(bookdetail)

        /*
        end creat book details
        */

        let bookaction = document.createElement("div")
        bookaction.classList.add("book-actions")

        let edit = document.createElement("button")
        edit.classList.add("btn", "btn-edit")
        edit.textContent = "✏️ Edit"

        let Delete = document.createElement("button")
        Delete.classList.add("btn", "btn-delete")
        Delete.textContent = "🗑️ Delete"


        grid.addEventListener("click", function (e) {
            e.preventDefault();
            if (e.target.classList.contains("btn-delete")) {
                let card = e.target.closest(".book-card");

                card.remove();
            }

        })

        grid.addEventListener("click", function (e) {

            e.preventDefault();

            if (e.target.classList.contains("book-title")) {
                let input = document.createElement("input");
                input.type = "text";
                input.value = e.target.textContent;
                input.classList.add("edit-input");

                e.target.parentNode.replaceChild(input, e.target);
                input.focus();

                input.addEventListener('blur', function () {
                    let newSpan = document.createElement('h3');
                    newSpan.classList.add('book-title');
                    newSpan.textContent = input.value;
                    input.parentNode.replaceChild(newSpan, input);
                });

            }

            if (e.target.classList.contains("book-author")) {
                let input = document.createElement("input");
                input.type = "text";
                input.value = e.target.textContent;
                input.classList.add("edit-input");

                e.target.parentNode.replaceChild(input, e.target);
                input.focus();

                input.addEventListener('blur', function () {
                    let newSpan = document.createElement('p');
                    newSpan.classList.add('book-author');
                    newSpan.textContent = input.value;
                    input.parentNode.replaceChild(newSpan, input);
                });

            }

            if (e.target.classList.contains("book-isbn")) {
                let input = document.createElement("input");
                input.type = "text";
                input.value = e.target.textContent;
                input.classList.add("edit-input");

                e.target.parentNode.replaceChild(input, e.target);
                input.focus();

                input.addEventListener('blur', function () {
                    let newSpan = document.createElement('p');
                    newSpan.classList.add('book-isbn');
                    newSpan.textContent = input.value;
                    input.parentNode.replaceChild(newSpan, input);
                });

            }

            if (e.target.classList.contains("detail-value")) {
                let input = document.createElement("input");
                input.type = "text";
                input.value = e.target.textContent;
                input.classList.add("edit-input");

                e.target.parentNode.replaceChild(input, e.target);
                input.focus();

                input.addEventListener('blur', function () {
                    let newSpan = document.createElement('span');
                    newSpan.classList.add('detail-value');
                    newSpan.textContent = input.value;
                    input.parentNode.replaceChild(newSpan, input);
                });

            }

            if (e.target.classList.contains("available")) {
                let unavaileb = document.createElement("span");
                unavaileb.classList.add("availability-badge", "unavailable")
                unavaileb.textContent = "Checked Out"
                e.target.parentNode.replaceChild(unavaileb, e.target);

            }



            if (e.target.classList.contains("unavailable")) {
                let availeb = document.createElement("span");
                availeb.classList.add("availability-badge", "available")
                availeb.textContent = "Available"
                e.target.parentNode.replaceChild(availeb, e.target);

            }

        });


        bookaction.appendChild(edit)
        bookaction.appendChild(Delete)

        bookCard.appendChild(bookaction)


        grid.appendChild(bookCard);

        input.value = "";
        input1.value = "";
        input2.value = "";
        input3.value = "";
        input4.value = "";
        input5.value = "";

    }



});
/* End BOOK JAVASCRIPT */

/*
Member Java script 
*/
let patable = document.querySelector(".table-container")
let table = document.querySelector(".table")
let addbook = document.querySelector(".btn-add")

addbook.addEventListener("click", function (e) {

    e.preventDefault();




    let tr = document.createElement("tr")
    let td1 = document.createElement("td")
    let td2 = document.createElement("td")
    let td3 = document.createElement("td")
    let td4 = document.createElement("td")

    let intd = document.createElement("input")
    intd.classList.add("edit-input");
    intd.value = td1.textContent;
    td1.textContent = "";
    td1.appendChild(intd)

    intd.focus();

    intd.addEventListener('blur', function () {
        td1.textContent = intd.value;
    })

    let intd1 = document.createElement("input")
    intd1.classList.add("edit-input");
    intd1.value = td2.textContent;
    td2.textContent = "";
    td2.appendChild(intd1)

    intd1.focus();

    intd1.addEventListener('blur', function () {
        td2.textContent = intd1.value;
    })

    let intd2 = document.createElement("input")
    intd2.classList.add("edit-input");
    intd2.value = td3.textContent;
    td3.textContent = "";
    td3.appendChild(intd2)

    intd2.focus();

    intd2.addEventListener('blur', function () {
        td3.textContent = intd2.value;
    })

    let intd3 = document.createElement("input")
    intd3.classList.add("edit-input");
    intd3.value = td4.textContent;
    td4.textContent = "";
    td4.appendChild(intd3)

    intd3.focus();
    intd3.addEventListener('blur', function () {
        td4.textContent = intd3.value;
    })

    let td5 = document.createElement("td")

    let statusSpan = document.createElement("span");
    statusSpan.className = "badge badge-active";
    statusSpan.textContent = "Active";
    td5.appendChild(statusSpan);

    let td6 = document.createElement("td")

    let actions = document.createElement("div")
    actions.classList.add("action-buttons")
    let Booksbutt = document.createElement("button")
    Booksbutt.className = "btn btn-view";
    Booksbutt.textContent = "📚 Books";

    let editbutt = document.createElement("button")
    editbutt.className = "btn btn-edit";
    editbutt.textContent = "✏️ Edit";

    let delbutt = document.createElement("button")
    delbutt.className = "btn btn-delete";
    delbutt.textContent = "🗑️ Delete";


    td6.appendChild(actions);
    tr.appendChild(td1);
    tr.appendChild(td2);
    tr.appendChild(td3);
    tr.appendChild(td4);
    tr.appendChild(td5);
    actions.appendChild(Booksbutt);
    actions.appendChild(editbutt);
    actions.appendChild(delbutt);
    td6.appendChild(actions);
    tr.appendChild(td6);

    let par = document.querySelector(".table tbody")

    par.addEventListener("click", function (e) {
    if (e.target.classList.contains("btn-edit")) {
        const row = e.target.closest("tr"); 
        const cells = row.querySelectorAll("td"); 
        
        cells.forEach(td => {
            if (!td.querySelector("button") && !td.querySelector("input")) {
                const input = document.createElement("input");
                input.type = "text";
                input.value = td.textContent;
                input.classList.add("edit-input");

                td.textContent = "";
                td.appendChild(input);

                input.addEventListener("blur", function () {
                    td.textContent = input.value;
                });
            }
        });
        
        row.querySelector("input")?.focus();
    }
});


par.addEventListener("click", function(e){
    if(e.target.classList.contains("btn-delete")){
         let del = e.target.closest("tr");
         del.remove();

    }
})


par.addEventListener("click", function(e){
     if(e.target.classList.contains("btn-view")) { 
        const row = e.target.closest("tr");
        const memberName = row.querySelectorAll("td")[1].textContent;
   alert(
            `📚 Oops! Looks like ${memberName} hasn’t borrowed any books yet.\n` +
            `Or maybe our secret library database is taking a coffee break ☕😆\n` +
            `(This feature will work once we connect it to a real database!)`
        );        
    }
});

    document.querySelector(".table tbody").appendChild(tr);
    patable.appendChild(table);

});

/*
End Member Javascript 
*/


/* STAFF JAVASCRIPT */
let addStaff = document.querySelector(".btn-add");
let cardsGrid = document.querySelector(".books-grid");

let staffName = document.querySelector("#staffName");
let staffTitle = document.querySelector("#staffTitle");
let staffEmail = document.querySelector("#staffEmail");
let staffPhone = document.querySelector("#staffPhone");
let staffBranch = document.querySelector("#staffBranch");

addStaff.addEventListener("click", function (e) {
    e.preventDefault();
    
    let nameValue = staffName.value;
    let titleValue = staffTitle.value;
    let emailValue = staffEmail.value;
    let phoneValue = staffPhone.value;
    let branchValue = staffBranch.value;
    
    if (nameValue != "") {
        let dataCard = document.createElement("div");
        dataCard.classList.add("book-card");
        
        /* create card header */
        let cardHeader = document.createElement("div");
        cardHeader.classList.add("book-header");
        
        let div = document.createElement("div");
        
        let cardTitle = document.createElement("h3");
        cardTitle.classList.add("book-title");
        cardTitle.textContent = nameValue;
        
        let cardSubtitle = document.createElement("p");
        cardSubtitle.classList.add("book-subtitle");
        cardSubtitle.textContent = titleValue;
        
        let iconBadge = document.createElement("div");
        iconBadge.classList.add("icon-badge");
        iconBadge.textContent = "👨‍💼";
        
        div.appendChild(cardTitle);
        div.appendChild(cardSubtitle);
        cardHeader.appendChild(div);
        cardHeader.appendChild(iconBadge);
        dataCard.appendChild(cardHeader);
        /* end create card header */
        
        /* create card details */
        let cardDetails = document.createElement("div");
        cardDetails.classList.add("book-details");
        
        let detailRow1 = document.createElement("div");
        detailRow1.classList.add("detail-row");
        let detailLabel1 = document.createElement("span");
        detailLabel1.classList.add("detail-label");
        detailLabel1.textContent = "Email:";
        let detailValue1 = document.createElement("span");
        detailValue1.classList.add("detail-value");
        detailValue1.textContent = emailValue;
        detailRow1.appendChild(detailLabel1);
        detailRow1.appendChild(detailValue1);
        
        let detailRow2 = document.createElement("div");
        detailRow2.classList.add("detail-row");
        let detailLabel2 = document.createElement("span");
        detailLabel2.classList.add("detail-label");
        detailLabel2.textContent = "Phone:";
        let detailValue2 = document.createElement("span");
        detailValue2.classList.add("detail-value");
        detailValue2.textContent = phoneValue;
        detailRow2.appendChild(detailLabel2);
        detailRow2.appendChild(detailValue2);
        
        let detailRow3 = document.createElement("div");
        detailRow3.classList.add("detail-row");
        let detailLabel3 = document.createElement("span");
        detailLabel3.classList.add("detail-label");
        detailLabel3.textContent = "Branch:";
        let detailValue3 = document.createElement("span");
        detailValue3.classList.add("detail-value");
        detailValue3.textContent = branchValue;
        detailRow3.appendChild(detailLabel3);
        detailRow3.appendChild(detailValue3);
        
        let detailRow4 = document.createElement("div");
        detailRow4.classList.add("detail-row");
        let detailLabel4 = document.createElement("span");
        detailLabel4.classList.add("detail-label");
        detailLabel4.textContent = "Status:";
        let detailValue4 = document.createElement("span");
        detailValue4.classList.add("badge", "badge-active");
        detailValue4.textContent = "Active";
        detailRow4.appendChild(detailLabel4);
        detailRow4.appendChild(detailValue4);
        
        cardDetails.appendChild(detailRow1);
        cardDetails.appendChild(detailRow2);
        cardDetails.appendChild(detailRow3);
        cardDetails.appendChild(detailRow4);
        dataCard.appendChild(cardDetails);
        /* end create card details */
        
        let cardActions = document.createElement("div");
        cardActions.classList.add("book-actions");
        
        let edit = document.createElement("button");
        edit.classList.add("btn", "btn-edit");
        edit.textContent = "✏️ Edit";
        
        let deleteBtn = document.createElement("button");
        deleteBtn.classList.add("btn", "btn-delete");
        deleteBtn.textContent = "🗑️ Remove";
        
        // Delete functionality
        cardsGrid.addEventListener("click", function (e) {
            e.preventDefault();
            if (e.target.classList.contains("btn-delete")) {
                let card = e.target.closest(".book-card");
                card.remove();
            }
        });
        
        // Edit functionality
        cardsGrid.addEventListener("click", function (e) {
            e.preventDefault();
            
            if (e.target.classList.contains("book-title")) {
                let input = document.createElement("input");
                input.type = "text";
                input.value = e.target.textContent;
                input.classList.add("edit-input");
                e.target.parentNode.replaceChild(input, e.target);
                input.focus();
                input.addEventListener('blur', function () {
                    let newSpan = document.createElement('h3');
                    newSpan.classList.add('book-title');
                    newSpan.textContent = input.value;
                    input.parentNode.replaceChild(newSpan, input);
                });
            }
            
            if (e.target.classList.contains("card-subtitle")) {
                let input = document.createElement("input");
                input.type = "text";
                input.value = e.target.textContent;
                input.classList.add("edit-input");
                e.target.parentNode.replaceChild(input, e.target);
                input.focus();
                input.addEventListener('blur', function () {
                    let newSpan = document.createElement('p');
                    newSpan.classList.add('card-subtitle');
                    newSpan.textContent = input.value;
                    input.parentNode.replaceChild(newSpan, input);
                });
            }
            
            if (e.target.classList.contains("detail-value")) {
                let input = document.createElement("input");
                input.type = "text";
                input.value = e.target.textContent;
                input.classList.add("edit-input");
                e.target.parentNode.replaceChild(input, e.target);
                input.focus();
                input.addEventListener('blur', function () {
                    let newSpan = document.createElement('span');
                    newSpan.classList.add('detail-value');
                    newSpan.textContent = input.value;
                    input.parentNode.replaceChild(newSpan, input);
                });
            }
            
            if (e.target.classList.contains("badge-active")) {
                let onLeave = document.createElement("span");
                onLeave.classList.add("badge", "badge-pending");
                onLeave.textContent = "On Leave";
                e.target.parentNode.replaceChild(onLeave, e.target);
            }
            
            if (e.target.classList.contains("badge-pending")) {
                let active = document.createElement("span");
                active.classList.add("badge", "badge-active");
                active.textContent = "Active";
                e.target.parentNode.replaceChild(active, e.target);
            }
        });
        
        cardActions.appendChild(edit);
        cardActions.appendChild(deleteBtn);
        dataCard.appendChild(cardActions);
        cardsGrid.appendChild(dataCard);
        
        staffName.value = "";
        staffTitle.value = "";
        staffEmail.value = "";
        staffPhone.value = "";
        staffBranch.value = "";
    }
});



/* END STAFF JAVASCRIPT */
