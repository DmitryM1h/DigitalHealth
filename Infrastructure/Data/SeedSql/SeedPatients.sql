
--Пока без медкарты и остального
INSERT INTO "Telemetry"."Patients"("Id")
VALUES (gen_random_uuid());




-- запись к врачу
INSERT INTO "Telemetry"."Appointments"(
    "Id", "EventPeriod_StartDate", "EventPeriod_EndDate", "DoctorId", "PatientId")
VALUES (
    gen_random_uuid(), 
    '2024-01-15 10:00:00+03',
    '2024-01-15 11:00:00+03',
    '14ee900c-6acf-4d0b-aba7-d98d653298e2', 
    'd4a8138d-a232-431f-8392-5432c0640466'
);