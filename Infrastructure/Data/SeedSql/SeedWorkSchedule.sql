INSERT INTO "Telemetry"."WorkSchedules"(
    "Id", 
    "Monday_StartDate", "Monday_EndDate",
    "Tuesday_StartDate", "Tuesday_EndDate", 
    "Wednesday_StartDate", "Wednesday_EndDate",
    "Thursday_StartDate", "Thursday_EndDate",
    "Friday_StartDate", "Friday_EndDate",
    "Saturday_StartDate", "Saturday_EndDate",
    "Sunday_StartDate", "Sunday_EndDate"
)
SELECT 
    d."Id",
    -- Понедельник-четверг: 8:00-16:00
    CURRENT_DATE + TIME '08:00:00', CURRENT_DATE + TIME '16:00:00',
    CURRENT_DATE + TIME '08:00:00', CURRENT_DATE + TIME '16:00:00',
    CURRENT_DATE + TIME '08:00:00', CURRENT_DATE + TIME '16:00:00',
    CURRENT_DATE + TIME '08:00:00', CURRENT_DATE + TIME '16:00:00',
    -- Пятница: 8:00-15:00
    CURRENT_DATE + TIME '08:00:00', CURRENT_DATE + TIME '15:00:00',
    -- Суббота: у 50% врачей 9:00-13:00
    CASE WHEN MOD(ROW_NUMBER() OVER (), 2) = 0 THEN CURRENT_DATE + TIME '09:00:00' ELSE NULL END,
    CASE WHEN MOD(ROW_NUMBER() OVER (), 2) = 0 THEN CURRENT_DATE + TIME '13:00:00' ELSE NULL END,
    -- Воскресенье: выходной
    NULL, NULL
FROM "Telemetry"."Doctors" d
WHERE NOT EXISTS (
    SELECT 1 FROM "Telemetry"."WorkSchedules" ws 
    WHERE ws."Id" = d."Id"
);