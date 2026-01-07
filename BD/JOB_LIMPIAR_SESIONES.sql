BEGIN
  -- Si existe, lo elimina
  DBMS_SCHEDULER.DROP_JOB('JOB_LIMPIAR_SESIONES', FORCE => TRUE);
EXCEPTION
  WHEN OTHERS THEN
    IF SQLCODE != -27475 THEN -- error "job no existe"
      RAISE;
    END IF;
END;
/

BEGIN
  DBMS_SCHEDULER.CREATE_JOB (
    job_name        => 'JOB_LIMPIAR_SESIONES',
    job_type        => 'PLSQL_BLOCK',
    job_action      => '
      BEGIN
        DELETE FROM SESION 
        WHERE ACTIVO = 0 
           OR FECHA_EXPIRACION < SYSDATE;
        COMMIT;
      END;',
    start_date      => SYSTIMESTAMP,
    repeat_interval => 'FREQ=SECONDLY; INTERVAL=5',
    enabled         => TRUE,
    comments        => 'Elimina registros inactivos o expirados de la tabla SESION cada 5 segundos'
  );
END;
/


SELECT job_name, enabled, state, last_start_date, next_run_date
FROM dba_scheduler_jobs
WHERE job_name = 'JOB_LIMPIAR_SESIONES';