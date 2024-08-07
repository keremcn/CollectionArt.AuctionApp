$(function () {
    var l = abp.localization.getResource('AuctionAppResource');
    var editModal = new abp.ModalManager(abp.appPath + 'Auctions/EditModal');
    var dataTable = $('#AuctionsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[4, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(collectionArt.auctionApp.services.auctions.auction.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    },
                                    visible: abp.auth.isGranted('AuctionApp.Auctions.Edit'), //CHECK for the PERMISSION
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('AuctionApp.Auctions.Delete'),
                                    confirmMessage: function (data) {
                                        return l('ItemDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        collectionArt.auctionApp.services.auctions.auction
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }

                            ]
                    }
                },
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


    var createModal = new abp.ModalManager(abp.appPath + 'Auctions/CreateModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });


    $('#NewAuctionButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
