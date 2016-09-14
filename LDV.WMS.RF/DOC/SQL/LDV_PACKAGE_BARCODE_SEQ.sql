----------------------------------------------------
-- Export file for user LDVWMS                    --
-- Created by Administrator on 2012-3-30, 9:56:11 --
----------------------------------------------------

spool LDV_PACKAGE_BARCODE_SEQ.log

prompt
prompt Creating sequence LDV_PACKAGE_BARCODE_SEQ
prompt =========================================
prompt
create sequence LDVWMS.LDV_PACKAGE_BARCODE_SEQ
minvalue 1
maxvalue 99999999999999999999999999
start with 1
increment by 1
cache 20;


spool off
