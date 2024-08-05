$(function () {
    var l = abp.localization.getResource('AuctionApp');
    var editModal = new abp.ModalManager(abp.appPath + 'Items/EditModal');
    var dataTable = $('#ItemsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(collectionArt.auctionApp.services.items.item.getList),
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
                                    visible: abp.auth.isGranted('AuctionApp.Items.Edit'), //CHECK for the PERMISSION
                                }, {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('AuctionApp.Items.Delete'),
                                    confirmMessage: function (data) {
                                        return l('ItemDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        collectionArt.auctionApp.services.items.item
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
                //{
                //    title: l('OwnerId'),
                //    data: "ownerId"
                //},
                //{
                //    title: l('FirstOwnerId'),
                //    data: "firstOwnerId"
                //},
                {
                    title: l('Title'),
                    data: "title"
                }
                ,
                {
                    title: l('Description'),
                    data: "description"
                }
            ]
        })
    );

    var createModal = new abp.ModalManager(abp.appPath + 'Items/CreateModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });


    $('#NewItemButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
