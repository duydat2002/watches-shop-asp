// Dropdown
function dropdownActive() {
    const containers = document.querySelectorAll(`.select-box`);

    containers.forEach((container) => {
        const titleBox = container.querySelector(".select-box-title");
        const dropdown = container.querySelector(".select-box-list");

        titleBox.addEventListener("click", () => {
            dropdown.classList.toggle("active");
        })

        window.addEventListener("click", (e) => {
            if (!container.contains(e.target)) {
                dropdown.classList.remove("active");
            }
        })
    })

}
dropdownActive();

function renderListSelect() {
    const colors = ["Black", "White", "Sliver", "Gold", "Blue", "Green", "Red", "Brown", "Pink", "Purple"];
    const selectColor = document.querySelector(".select-color .select-box-list");

    colors.forEach((color) => {
        selectColor.innerHTML += `
            <div class="select-item">
                <input type="radio" name="color" value="${color}">
                <span class="color-box color-item color-${color.toLowerCase()}"></span>
                <span class="color-name">${color}</span>
            </div>
        `;
    })
    document.querySelector(".select-color input[name='color']").checked = true;

    const selectStars = document.querySelector(".select-stars .select-box-list");
    for (let i = 5; i >= 0; i -= 0.5) {
        selectStars.innerHTML += `
            <div class="select-item">
                <input type="radio" name="stars" value="${i}">
                <span class="stars-text">${i}</span>
                <div class="stars-list">
                    ${renderStars(i)}
                </div>
            </div>
        `;
    }
    document.querySelector(".select-stars input[name='stars']").checked = true;

    const types = ["Men", "Women", "Sport", "Luxury", "New", "Special"];
    const selectType = document.querySelector(".select-type .select-box-list");

    types.forEach(type => {
        selectType.innerHTML += `
            <div class="select-item">
                <div class="checkbox-box">
                    <i class="fas fa-check checkbox-icon"></i>
                </div>
                <span class="type-name">${type}</span>
            </div>
        `;
    })
}
renderListSelect();

// Render Input From Querystring
function renderQuerystring() {
    const params = new URLSearchParams(window.location.search);
    const imgShow = document.querySelector(".imgs-show");

    imgShow.innerHTML = "";
    document.querySelector("#id").value = params.get("id");
    document.querySelector("#name").value = params.get("name");
    document.querySelector("#price").value = params.get("price");
    document.querySelector("#discount").value = params.get("discount");
    document.querySelector("#desc").value = params.get("desc");
    document.querySelector("#size").value = params.get("size");
    const colorCheck = document.querySelector(`.select-color input[value='${params.get("color")}']`);
    if (colorCheck)
        colorCheck.checked = true;
    const starsCheck = document.querySelector(`.select-stars input[value='${params.get("stars")}']`);
    if (starsCheck)
        starsCheck.checked = true;
    document.querySelector("#type").value = params.get("type");
    document.querySelector("#alts").value = params.get("alts");

    var alts = document.querySelector("#alts").value.split(",");
    if (alts[0] != "") {
        alts.forEach((alt) => {
            imgShow.innerHTML += `
                <div class="col-2 pd-gap">
                    <div class="img-item">
                        <img src="assets/image/${alt}" alt="${alt}">
                    </div>
                </div>
            `;
        })
    }
}
renderQuerystring();

function colorDropdown() {
    const container = document.querySelector(`.select-color`);
    const valueBox = container.querySelector(".select-box-value");
    const listCheckbox = container.querySelector(".select-box-list");
    const selectItem = listCheckbox.querySelectorAll(".select-item");

    selectItem.forEach(item => {
        item.onclick = () => {
            const color = item.querySelector(".color-name").innerHTML;
            valueBox.innerHTML = `
                <span class="color-box color-item color-${color.toLowerCase()}" data-value="${color}"></span>
                <span class="color-name">${color}</span>
            `;
            listCheckbox.classList.remove("active");
        }
    })
};
colorDropdown();

function starsDropdown() {
    const container = document.querySelector(`.select-stars`);
    const valueBox = container.querySelector(".select-box-value");
    const listCheckbox = container.querySelector(".select-box-list");
    const selectItem = listCheckbox.querySelectorAll(".select-item");

    selectItem.forEach(item => {
        item.onclick = () => {
            const star = item.querySelector(".stars-text").innerHTML;
            valueBox.innerHTML = `
                <span class="stars-text">${star}</span>
                <div class="stars-list">
                    ${renderStars(star)}
                </div>
            `;
            listCheckbox.classList.remove("active");
        }
    })
};
starsDropdown();

function typeDropdown() {
    const container = document.querySelector(`.select-type`);
    const inputType = container.querySelector("input[name='type']");
    const selectItem = container.querySelectorAll(".select-item");
    var listType = inputType.value == "" ? [] : inputType.value.split(", ");

    selectItem.forEach(item => {
        item.onclick = () => {
            const checkbox = item.querySelector(".checkbox-box");
            const type = item.querySelector(".type-name").innerHTML;

            if (checkbox.className.includes("active")) {
                checkbox.classList.remove("active");
                listType.splice(listType.indexOf(type), 1);
            } else {
                checkbox.classList.add("active");
                listType.push(type);
            }

            inputType.value = listType.join(", ");
        }
    })
}
typeDropdown();

function autoChangeValue() {
    const starsValueCTN = document.querySelector(".select-stars .select-box-value");
    const starsValue = document.querySelector(".select-stars input[name='stars']:checked").value;

    starsValueCTN.innerHTML = `
        <span class="stars-text">${starsValue}</span>
        <div class="stars-list">
            ${renderStars(starsValue)}
        </div>
    `;

    const colorValueCTN = document.querySelector(".select-color .select-box-value");
    const colorValue = document.querySelector(".select-color input[name='color']:checked").value;

    colorValueCTN.innerHTML = `
        <span class="color-box color-item color-${colorValue.toLowerCase()}"></span>
        <span class="color-name">${colorValue}</span>
    `;

    const typeInput = document.querySelector("#type").value;
    const selectTypeItems = document.querySelectorAll(".select-type .select-item");

    selectTypeItems.forEach((item) => {
        const typeName = item.querySelector(".type-name").innerHTML;
        const selectBox = item.querySelector(".checkbox-box");
        if (typeInput.includes(typeName)) {
            selectBox.classList.add("active");
        }
    })
}
autoChangeValue();

// Validate Form 
function validateProduct() {
    const name = document.querySelector("#name").value.trim();
    const price = document.querySelector("#price").value.trim();
    const discount = document.querySelector("#discount").value.trim();
    const size = document.querySelector("#size").value.trim();
    const type = document.querySelector("#type").value.trim();
    const desc = document.querySelector("#desc").value.trim();
    const alts = document.querySelector("#alts");

    const nameError = document.querySelector("#name_error");
    const priceError = document.querySelector("#price_error");
    const discountError = document.querySelector("#discount_error");
    const sizeError = document.querySelector("#size_error");
    const typeError = document.querySelector("#type_error");
    const descError = document.querySelector("#desc_error");
    const imgsError = document.querySelector("#imgs_error");

    var check = true;

    if (name == "") {
        nameError.innerHTML = "Please enter product name.";
        check = false;
    } else {
        nameError.innerHTML = "";
    }

    if (price == "") {
        priceError.innerHTML = "Please enter product price.";
        check = false;
    } else if (isNaN(price)) {
        priceError.innerHTML = "Please enter the number.";
        check = false;
    } else if (parseFloat(price) <= 0) {
        priceError.innerHTML = "Price must be greater than 0.";
        check = false;
    } else {
        priceError.innerHTML = "";
    }

    if (discount == "") {
        discountError.innerHTML = "Please enter product discount.";
        check = false;
    } else if (isNaN(discount)) {
        discountError.innerHTML = "Please enter the number.";
        check = false;
    } else if (parseFloat(discount) < 0 || parseFloat(discount) > 100) {
        discountError.innerHTML = "Discount must be between 0 and 100.";
        check = false;
    } else {
        discountError.innerHTML = "";
    }

    if (size == "") {
        sizeError.innerHTML = "Please enter product size.";
        check = false;
    } else if (isNaN(size)) {
        sizeError.innerHTML = "Please enter the number.";
        check = false;
    } else if (parseFloat(size) <= 0) {
        sizeError.innerHTML = "Size must be greater than 0.";
        check = false;
    } else {
        sizeError.innerHTML = "";
    }

    if (type == "") {
        typeError.innerHTML = "Please enter product type.";
        check = false;
    } else {
        typeError.innerHTML = "";
    }

    if (desc == "") {
        descError.innerHTML = "Please enter product description.";
        check = false;
    } else {
        descError.innerHTML = "";
    }

    if (alts == "") {
        imgsError.innerHTML = "Number of images must be greater than 3.";
        check = false;
    } else {
        imgsError.innerHTML = "";
    }

    return check;
}

function checkFileUpload() {
    const alts = document.querySelector("#alts");
    const imgs = document.querySelector("#imgs");
    const imgShow = document.querySelector(".imgs-show");
    const imgsError = document.querySelector("#imgs_error");
    var check = true;
    var fileList;

    imgShow.innerHTML = "";
    alts.value = "";
    fileList = imgs.files;

    if (fileList.length < 4) {
        imgsError.innerHTML = "Number of images must be greater than 3.";
        check = false;
    } else {
        imgsError.innerHTML = "";
    }

    for (let i = 0; i < fileList.length; i++) {
        if (!fileList[i].type.includes("image")) {
            imgsError.innerHTML = "Uploaded file is not a valid image";
            check = false;
            break;
        }
    }

    if (check) {
        var altList = [];

        for (let i = 0; i < fileList.length; i++) {
            const srcImg = URL.createObjectURL(fileList[i]);

            imgShow.innerHTML += `
            <div class="col-2 pd-gap">
                <div class="img-item">
                    <img src=${srcImg} alt="">
                </div>
            </div>
            `;

            altList.push(fileList[i].name);
        }
        alts.value = altList.join(",");
    }

    return check;
}

function submitClick() {
    const imgs = document.querySelector("#imgs");

    imgs.addEventListener("change", () => {
        checkFileUpload();
    })

    const save = document.querySelector("#save");
    save.onclick = () => {
        return validateProduct();
    }

    const edit = document.querySelector("#edit");
    edit.onclick = () => {
        return validateProduct();
    }
}
submitClick();

function renderStars(stars) {
    var starsHTML = "";
    for (let i = 1; i <= 5; i++) {
        if (i <= stars)
            starsHTML += " <i class='fas fa-star'></i> ";
        else if (i - stars == 0.5)
            starsHTML += "<i class='fas fa-star-half-alt'></i> ";
        else
            starsHTML += "<i class='far fa-star'></i> ";
    }
    return starsHTML;
}

function closeDeleteModal() {
    const deleteModal = document.querySelector(".alertbox-delete");
    const deleteClose = document.querySelector(".alertbox-close");
    const cancelBtn = document.querySelector(".alertbox__button.button-cancel");

    deleteClose.addEventListener("click", () => {
        deleteModal.classList.remove("active");
    })
    cancelBtn.addEventListener("click", () => {
        deleteModal.classList.remove("active");
    })
}
closeDeleteModal();

function openDeleteModal() {
    const deleteModal = document.querySelector(".alertbox-delete");
    const productItems = document.querySelectorAll(".product-list .product-item");

    productItems.forEach((item) => {
        const deleteBtn = item.querySelector(".product-delete");

        deleteBtn.onclick = () => {
            const confirmDeleteBtn = deleteModal.querySelector(".button-delete");

            deleteModal.classList.add("active")
            confirmDeleteBtn.value = deleteBtn.dataset.id;
        }
    })
}
openDeleteModal();