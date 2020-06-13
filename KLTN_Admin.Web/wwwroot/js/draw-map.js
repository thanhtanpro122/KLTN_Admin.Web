_mapDrawer = {
    draw: (width, height, orderType, customHtml = '') => {
        let html = '<label class="dynamic-text">Sơ đồ chỗ ngồi trên xe</label>';
        switch (orderType) {
            case 'trai_qua_phai':
                return html + veTraiQuaPhai(width, height, customHtml);
            case 'phai_qua_trai':
                return html + vePhaiQuaTrai(width, height, customHtml);
            case 'duoi_len_tren':
                return html + veDuoiLenTren(width, height, customHtml);
            case 'tren_xuong_duoi':
                return html + veTrenXuongDuoi(width, height, customHtml);
        }

        return '';
    }
};

function setContent(number, customHtml = '') {
    if (customHtml) {
        customHtml = customHtml.replace(/{number}/g, number.toString());
        html = customHtml;
    } else {
        html = number.toString();
    }

    return `<td>${html}</td>`;
}

function veTraiQuaPhai(width, height, customHtml = '') {
    let count = 1;
    let html = '<table class="map">';
    for (let i = 1; i <= height; i++) {
        html += "<tr>";
        for (let j = 1; j <= width; j++) {
            html += setContent(count++, customHtml);
        }
        html += "</tr>";
    }
    html += "</table>";

    return html;
}

function vePhaiQuaTrai(width, height, customHtml = '') {
    let html = '<table class="map">';
    for (let i = 1; i <= height; i++) {
        let count = width * i;
        html += "<tr>";
        for (let j = 1; j <= width; j++) {
            html += setContent(count--, customHtml);
        }
        html += "</tr>";
    }
    html += "</table>";

    return html;
}

function veTrenXuongDuoi(width, height, customHtml = '') {
    let html = '<table class="map">';

    for (let i = 1; i <= height; i++) {
        html += "<tr>";
        for (let j = 1; j <= width; j++) {
            let count = ((width - j) * height) + i;
            html += setContent(count, customHtml);
        }
        html += "</tr>";
    }
    html += "</table>";

    return html;
}

function veDuoiLenTren(width, height, customHtml = '') {
    let html = '<table class="map">';

    for (let i = 1; i <= height; i++) {
        html += "<tr>";
        for (let j = 1; j <= width; j++) {
            let count = ((width - j + 1) * height) - i + 1;
            html += setContent(count, customHtml);
        }
        html += "</tr>";
    }
    html += "</table>";

    return html;
}