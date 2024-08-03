$(function () {
    var l = abp.localization.getResource('AuctionAppResource');

    var dataTable = $('#AuctionsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(collectionArt.auctionApp.services.auctions.auction.getList),
            columnDefs: [
                {
                    title: l('StartPrice'),
                    data: "startPrice"
                },
                {
                    title: l('ItemId'),
                    data: "itemId"
                },
                {
                    title: l('AuctionStatus'),
                    data: "auctionStatus",
                    render: function (data) {
                        return l('Enum:AuctionStatus.' + data);
                    }
                },
                //{
                //    title: l('PublishDate'),
                //    data: "publishDate",
                //    render: function (data) {
                //        return luxon
                //            .DateTime
                //            .fromISO(data, {
                //                locale: abp.localization.currentCulture.name
                //            }).toLocaleString();
                //    }
                //},
                //{
                //    title: l('Price'),
                //    data: "price"
                //},
                {
                    title: l('StartDate'), data: "startDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }, {
                    title: l('EndDate'), data: "endDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );
});
